using AutoMapper;
using StockAndBuyTestApp.Application.Products.Commands.CreateProduct;
using StockAndBuyTestApp.Contracts.Products;

namespace StockAndBuyTestApp.Api.Common.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
    }
}