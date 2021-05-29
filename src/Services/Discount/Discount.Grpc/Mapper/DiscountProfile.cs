using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Grpc.Protos;
using AutoMapper;

namespace amznStore.Services.Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<CouponModel, Coupon>();
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
