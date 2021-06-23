using amznStore.Services.Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace amznStore.Services.Discount.Infrastructure.DataContexts
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasData (
                new Coupon
                {
                    Id = 1,
                    CategoryName = "ALL",
                    CouponCode = "ABC-XYZ",
                    DiscountPercentage = 10,
                    ValidTill = DateTime.Today.AddMonths(2),
                    CouponCreated = DateTime.UtcNow.Date
                }
            );
        }
    }
}
