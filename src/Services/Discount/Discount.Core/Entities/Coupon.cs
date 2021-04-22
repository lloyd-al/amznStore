using System;

namespace amznStore.Services.Discount.Core.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string DiscountCode { get; set; }
        public int Discount { get; set; }
        public DateTime ValidTill { get; set; }
    }
}
