using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amznStore.Services.Discount.Core.Entities
{
    public class Coupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public decimal DiscountPercentage { get; set; }

        public DateTime ValidTill { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CouponCreated { get; set; } = DateTime.UtcNow.Date;
    }
}
