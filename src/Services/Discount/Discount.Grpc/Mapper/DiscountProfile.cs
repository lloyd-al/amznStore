using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Grpc.Protos;
using AutoMapper;

namespace amznStore.Services.Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
