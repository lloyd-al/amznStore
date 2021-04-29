using AutoMapper;
using amznStore.Services.Ordering.Application.Responses;
using amznStore.Services.Ordering.Core.Entities;
using amznStore.Services.Ordering.Application.Services.Commands;

namespace amznStore.Services.Ordering.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}
