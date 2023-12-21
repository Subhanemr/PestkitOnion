using AutoMapper;
using PestkitOnion.Application.Dtos.Product;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ItemProductDto>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
        }
    }
}
