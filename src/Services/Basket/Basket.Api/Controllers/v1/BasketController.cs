using amznStore.Services.Basket.Api.GrpcServices;
using amznStore.Services.Basket.Core.Interfaces;
using amznStore.Services.Basket.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace amznStore.Services.Basket.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BasketController : RootController
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService, ILogger logger) : base(logger)
        {
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
                var coupon = await _discountGrpcService.GetDiscount(item.CategoryName);
                item.UnitPrice -= (item.UnitPrice * (coupon.Discount / 100));
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
            // remove the basket 
            // send checkout event to rabbitMq 

            var basket = await _repository.GetBasketAsync(basketCheckout.Buyer);
            if (basket == null)
            {
                _logger.Error("Basket not exist with this user : " + basketCheckout.Buyer);
                return BadRequest();
            }

            await _repository.DeleteBasketAsync(basketCheckout.Buyer);
            
            return Accepted();
        }
    }
}
