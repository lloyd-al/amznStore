using System;
using System.Collections.Generic;
using MediatR;
using amznStore.Services.Ordering.Application.Responses;

namespace amznStore.Services.Ordering.Application.Queries
{
    public class GetOrderDetailsQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderDetailsQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
