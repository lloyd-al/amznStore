using System;
using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.Discount.Api.DTOs
{
    public class CouponDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name is Required.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Code Code is Required.")]
        public string CouponCode { get; set; }
        [Required(ErrorMessage = "Discount Percentage is Required.")]
        [RegularExpression(@"(^100(\.0{1,2})?$)|(^([1-9]([0-9])?|0)(\.[0-9]{1,2})?$)", ErrorMessage = "Invalid Discount")]
        public decimal DiscountPercentage { get; set; }
        public DateTime ValidTill { get; set; }
        public DateTime CouponCreated { get; set; }
    }
}
