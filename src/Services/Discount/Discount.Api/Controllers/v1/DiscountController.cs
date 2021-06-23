using amznStore.Services.Discount.Api.ActionFilters;
using amznStore.Services.Discount.Api.DTOs;
using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DiscountController : RootController
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountRepository repository, ILogger logger, IMapper mapper) : base(logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetCoupons")]
        [ProducesResponseType(typeof(IEnumerable<Coupon>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetAll()
        {
            var coupons = await _repository.GetAllCoupons(trackChanges: false);
            var couponsDto = _mapper.Map<IEnumerable<CouponDto>>(coupons);
            return Ok(couponsDto);
        }

        [HttpGet("{id}", Name = "GetCoupon")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetById(int id)
        {
            var coupon = await _repository.GetCoupon(id, trackChanges: false);
            if (coupon == null)
            {
                _logger.Information($"Coupon with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var couponDto = _mapper.Map<CouponDto>(coupon);
                return Ok(couponDto);
            }
        }

        [Route("[action]/{couponCode}")]
        [HttpGet]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> VerifyCoupon(string couponCode)
        {
            var coupon = await _repository.VerifyCoupon(couponCode, trackChanges: false);
            if (coupon == null)
            {
                _logger.Information($"Coupon with code: {couponCode} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var couponDto = _mapper.Map<CouponDto>(coupon);
                return Ok(couponDto);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] CouponDto coupon)
        {
            var couponEntity = _mapper.Map<Coupon>(coupon);
            _repository.CreateCoupon(couponEntity);
            await _repository.SaveChangesAsync();

            var couponToReturn = _mapper.Map<CouponDto>(couponEntity);

            return CreatedAtRoute("GetCoupon", new { id = couponToReturn.Id }, couponToReturn);
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateBasket([FromBody] CouponDto coupon)
        {
            var couponEntity = _mapper.Map<Coupon>(coupon);
            _repository.UpdateCoupon(couponEntity);
            await _repository.SaveChangesAsync();
            return Ok(coupon);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(int id)
        {
            var coupon = await _repository.GetCoupon(id, trackChanges: false);
            if (coupon == null)
            {
                _logger.Information($"Coupon with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                _repository.DeleteCoupon(coupon);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
