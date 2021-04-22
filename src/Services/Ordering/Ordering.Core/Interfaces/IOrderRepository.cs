using amznStore.Services.Ordering.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.Ordering.Core.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string buyer);
    }
}
