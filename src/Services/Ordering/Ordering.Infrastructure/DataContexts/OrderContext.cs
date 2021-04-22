using amznStore.Services.Ordering.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace amznStore.Services.Ordering.Infrastructure.DataContexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
