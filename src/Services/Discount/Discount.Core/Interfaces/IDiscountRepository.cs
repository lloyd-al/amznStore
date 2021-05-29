using amznStore.Services.Discount.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Core.Interfaces
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Coupon>> GetAllCoupons(bool trackChanges);
        Task<Coupon> GetCoupon(int id, bool trackChanges);
        Task<Coupon> VerifyCoupon(string couponCode, bool trackChanges);
        void CreateCoupon(Coupon coupon);
        void UpdateCoupon(Coupon coupon);
        void DeleteCoupon(Coupon coupon);
        Task SaveChangesAsync();
    }
}
