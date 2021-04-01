using System;

namespace amznStore.Services.Catalog.Application.DTOs
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
    }
}
