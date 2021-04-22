using AutoMapper;
using amznStore.Services.Ordering.Application.Commands;
using amznStore.Services.Ordering.Application.Responses;
using amznStore.Services.Ordering.Core.Entities;

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
