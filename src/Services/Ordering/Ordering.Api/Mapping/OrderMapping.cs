using AutoMapper;
using amznStore.Services.Ordering.Application.Services.Commands;
using amznStore.Common.EventBus.Messages.Events;

namespace amznStore.Services.Ordering.Api.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<BasketCheckoutEvent, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
