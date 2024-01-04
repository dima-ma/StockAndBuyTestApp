using AutoMapper;
using StockAndBuyTestApp.Application.Stocks.Commands.CreateStock;
using StockAndBuyTestApp.Contracts.Stock;
using StockAndBuyTestApp.Domain.Stock;
using StockAndBuyTestApp.Domain.Stock.ValueObjects;

namespace StockAndBuyTestApp.Api.Common.Mapping;

public class StockMappingProflie : Profile
{
    public StockMappingProflie()
    {
        CreateMap<CreateStockRequest, CreateStockCommand>();
        CreateMap<StockId, Guid>().ConvertUsing(pid => pid.Value);
        CreateMap<Stock, StockResponse>()
            .ConstructUsing(src => new StockResponse(
                src.Id.Value,
                src.ProductId.Value,
                src.Count,
                src.CreatedDateTime,
                src.UpdatedDateTime
            ));
    }
}