using amznStore.Services.Basket.Api.GrpcServices;
using amznStore.Services.Basket.Core.Interfaces;
using amznStore.Services.Basket.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using MassTransit;
using amznStore.Common.EventBus.Messages.Events;
using AutoMapper;

namespace amznStore.Services.Basket.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BasketController : RootController
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService, ILogger logger, IPublishEndpoint publishEndpoint, IMapper mapper) : base(logger)
        {
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string buyerId)
        {
            var basket = await _repository.GetBasketAsync(buyerId);
            return Ok(basket ?? new CustomerBasket(buyerId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasket basket)
        {
            // Communicate with Discount. Grpc and calculate lastest prices of products into shopping cart
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(Convert.ToInt32(item.Id));
                var discount = Decimal.Divide(Convert.ToDecimal(coupon.DiscountPercentage), 100);
                item.UnitPrice -= item.UnitPrice * discount;
            }

            return Ok(await _repository.UpdateBasketAsync(basket));
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string buyerId)
        {
            await _repository.DeleteBasketAsync(buyerId);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            // get total price of the basket
            var basket = await _repository.GetBasketAsync(basketCheckout.Buyer);
            if (basket == null)
            {
                _logger.Error("Basket not exist with this user : " + basketCheckout.Buyer);
                return BadRequest();
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish<BasketCheckoutEvent>(eventMessage);

            // remove the basket 
            await _repository.DeleteBasketAsync(basketCheckout.Buyer);
            
            return Accepted();
        }
    }
}
