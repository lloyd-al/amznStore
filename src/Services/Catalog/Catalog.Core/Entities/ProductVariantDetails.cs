using System;
using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.Catalog.Core.Entities
{
    public class ProductVariantDetails
    {
        public string Variant { get; set; }
        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Invalid Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Price")]
        public decimal Price { get; set; }
    }
}
