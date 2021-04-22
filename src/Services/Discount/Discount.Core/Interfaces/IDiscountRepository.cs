﻿using amznStore.Services.Discount.Core.Entities;
using System.Threading.Tasks;

namespace amznStore.Services.Discount.Core.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string CategorytName);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string CategorytName);
    }
}
