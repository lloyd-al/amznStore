using amznStore.Services.Ordering.Application.Mapper;
using amznStore.Services.Ordering.Application.Queries;
using amznStore.Services.Ordering.Application.Responses;
using amznStore.Services.Ordering.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace amznStore.Services.Ordering.Application.Handlers
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);

            var orderResponseList = OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orderList);
            return orderResponseList;
        }
    }
}
