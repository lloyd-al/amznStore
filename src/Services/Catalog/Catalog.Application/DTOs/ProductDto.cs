using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.Catalog.Application.DTOs
{
    public class ProductDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is a required field.")]
        public string Category { get; set; }
        
        public string Summary { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
        
        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Invalid Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Price")]
        public decimal CurrentPrice { get; set; }

        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "Invalid Price")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Price")]
        public decimal OriginalPrice { get; set; }
        
        public List<ProductVariantDetailsDto> VariantDetails { get; set; }
        
        public CategoryDto CategoryDetail { get; set; }
    }
}
