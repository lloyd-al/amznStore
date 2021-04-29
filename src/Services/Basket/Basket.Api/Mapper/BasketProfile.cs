using amznStore.Common.EventBus.Messages.Events;
using amznStore.Services.Basket.Core.Entities;
using AutoMapper;

namespace amznStore.Services.Basket.Api.Mapper
{
	public class BasketProfile : Profile
	{
		public BasketProfile()
		{
			CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
