using System;
using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.Catalog.Application.DTOs
{
    public class ProductVariantDetailsDto
    {
        public string Variant { get; set; }

        public int Quantity { get; set; }

        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Invalid Price")]
        [Range(0, 100.00, ErrorMessage = "Invalid Price")]
        public decimal Discount { get; set; }
    }
}
