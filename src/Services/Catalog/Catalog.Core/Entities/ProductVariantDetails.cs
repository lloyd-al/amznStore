using System;
using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.Catalog.Core.Entities
{
    public class ProductVariantDetails
    {
        public string Variant { get; set; }

        public int Quantity { get; set; }
        
        public decimal Discount { get; set; }
    }
}
