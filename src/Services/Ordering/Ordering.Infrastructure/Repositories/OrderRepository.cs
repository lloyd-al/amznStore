using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amznStore.Services.Ordering.Core.Entities;
using amznStore.Services.Ordering.Core.Interfaces;
using amznStore.Services.Ordering.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace amznStore.Services.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                      .Where(o => o.Buyer == userName)
                      .ToListAsync();

            return orderList;
        }
    }
}
