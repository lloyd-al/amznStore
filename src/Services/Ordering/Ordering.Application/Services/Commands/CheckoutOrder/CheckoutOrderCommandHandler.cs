using System;
using System.Threading;
using System.Threading.Tasks;
using amznStore.Services.Ordering.Application.Commands;
using amznStore.Services.Ordering.Application.Mapper;
using amznStore.Services.Ordering.Core.Entities;
using amznStore.Services.Ordering.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace amznStore.Services.Ordering.Application.Handlers
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newOrder = await _orderRepository.AddAsync(orderEntity);
            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");
            return newOrder.Id;
        }
    }
}
