using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Core.Interfaces;
using amznStore.Services.Discount.Grpc.Protos;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Grpc
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRepository repository, IMapper mapper, ILogger<DiscountService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetCoupon(request.Id, false);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with Id {request.Id} not found"));
            }

            _logger.LogInformation("Coupon is retrieved for CategoryName : {categoryName}, Discount : {discount}%", coupon.Id, coupon.DiscountPercentage);

            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> VerifyDiscount(VerifyDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.VerifyCoupon(request.CouponCode, false);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with Coupon  Code {request.CouponCode} is not found or expired"));
            }

            _logger.LogInformation("Coupon is retrieved for Coupon Code : {couponCode}, Category Name : {categoryName}", coupon.CouponCode, coupon.CategoryName);

            //return Task.FromResult(_mapper.Map<CouponModel>(coupon));
            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            _repository.CreateCoupon(coupon);
            await _repository.SaveChangesAsync();
            _logger.LogInformation("Coupon is successfully created. CategoryName : {CategoryName}", coupon.CategoryName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            _repository.UpdateCoupon(coupon);
            await _repository.SaveChangesAsync();
            _logger.LogInformation("Coupon is successfully updated. CategoryName : {CategoryName}", coupon.CategoryName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            
            var coupon = await _repository.GetCoupon(request.Id, trackChanges: false);
            _repository.DeleteCoupon(coupon);
            await _repository.SaveChangesAsync();

            var response = new DeleteDiscountResponse
            {
                Success = true
            };

            return response;
        }
    }
}
