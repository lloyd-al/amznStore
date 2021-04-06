using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace amznStore.Services.Catalog.Core.Entities
{
    public class Product : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Category { get; set; }
        
        public string Summary { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        [BsonElementAttribute("variantdetails")]
        public List<ProductVariantDetails> VariantDetails { get; set; }
        
        [BsonIgnore]
        public Category CategoryDetail { get; set; }
    }
}
