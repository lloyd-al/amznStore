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
            var coupon = await _repository.GetDiscount(request.CategoryName);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with Category Name {request.CategoryName} not found"));
            }

            _logger.LogInformation("Discount is retrieved for CategoryName : {categoryName}, Discount : {discount}", coupon.CategoryName, coupon.Discount);

            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _repository.CreateDiscount(coupon);
            _logger.LogInformation("Discount is successfully created. CategoryName : {CategoryName}", coupon.CategoryName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _repository.UpdateDiscount(coupon);
            _logger.LogInformation("Discount is successfully updated. CategoryName : {CategoryName}", coupon.CategoryName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _repository.DeleteDiscount(request.CategoryName);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}
