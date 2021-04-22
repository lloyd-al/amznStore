using amznStore.Services.Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amznStore.Services.Basket.Api.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<CouponModel> GetDiscount(string categoryName)
        {
            var discountRequest = new GetDiscountRequest { CategoryName = categoryName };

            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }

    }
}
