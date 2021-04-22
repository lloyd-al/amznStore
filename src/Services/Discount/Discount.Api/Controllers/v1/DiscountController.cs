using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DiscountController : RootController
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository, ILogger logger) : base(logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{categoryName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string categoryName)
        {
            var discount = await _repository.GetDiscount(categoryName);
            return Ok(discount);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            await _repository.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { categoryName = coupon.CategoryName }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateBasket([FromBody] Coupon coupon)
        {
            return Ok(await _repository.UpdateDiscount(coupon));
        }

        [HttpDelete("{categoryName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string categoryName)
        {
            return Ok(await _repository.DeleteDiscount(categoryName));
        }
    }
}
