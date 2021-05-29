using amznStore.Services.Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace amznStore.Services.Discount.Infrastructure.DataContexts
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CouponConfiguration());
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
