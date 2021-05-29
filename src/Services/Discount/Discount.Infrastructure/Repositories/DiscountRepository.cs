using amznStore.Common.Infrastructure.Repositories;
using amznStore.Services.Discount.Core.Entities;
using amznStore.Services.Discount.Core.Interfaces;
using amznStore.Services.Discount.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Infrastructure.Repositories
{
    public class DiscountRepository : RepositoryBase<Coupon>, IDiscountRepository
    {
        public DiscountRepository(DiscountDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Coupon>> GetAllCoupons(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(c => c.CategoryName)
                    .ToListAsync();

        public async Task<Coupon> GetCoupon(int id, bool trackChanges) => 
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
                    .SingleOrDefaultAsync();

        public async Task<Coupon> VerifyCoupon(string couponCode, bool trackChanges) =>
            await FindByCondition(c => (c.CouponCode.Equals(couponCode) && c.ValidTill <= DateTime.UtcNow.Date), trackChanges)
                    .SingleOrDefaultAsync();

        public void CreateCoupon(Coupon coupon) => Add(coupon);

        public void UpdateCoupon(Coupon coupon) => Update(coupon);

        public void DeleteCoupon(Coupon coupon) => Delete(coupon);

        public Task SaveChangesAsync() => Save();
    }
}
