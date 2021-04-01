using amznStore.Services.Catalog.Application.DTOs;
using amznStore.Services.Catalog.Core.Entities;
using AutoMapper;

namespace amznStore.Services.Catalog.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<ProductVariantDetails, ProductVariantDetailsDto>();
            CreateMap<ProductVariantDetailsDto, ProductVariantDetails>().ReverseMap();
        }
    }
}
