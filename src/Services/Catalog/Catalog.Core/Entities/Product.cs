using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace amznStore.Services.Catalog.Core.Entities
{
    public class Product : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        public string ProductName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [Required(ErrorMessage = "Category is a required field.")]
        public string Category { get; set; }
        
        public string Summary { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        [BsonElementAttribute("variantdetails")]
        public List<ProductVariantDetails> VariantDetails { get; set; }
        
        [BsonIgnore]
        public Category CategoryDetail { get; set; }
    }
}
