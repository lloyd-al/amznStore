using amznStore.Services.Discount.Api.DTOs;
using amznStore.Services.Discount.Core.Entities;
using AutoMapper;

namespace amznStore.Services.Discount.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponDto>();
            CreateMap<CouponDto, Coupon>().ReverseMap();
        }

    }
}
