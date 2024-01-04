using AutoMapper;
using StockAndBuyTestApp.Application.Products.Commands.CreateProduct;
using StockAndBuyTestApp.Contracts.Products;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Api.Common.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>().ReverseMap();
        CreateMap<ProductId, Guid>().ConvertUsing(pid => pid.Value);
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
            .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => src.UpdatedDateTime));
    }
}