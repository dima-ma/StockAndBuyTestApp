using MediatR;
using StockAndBuyTestApp.Domain.Stock;

namespace StockAndBuyTestApp.Application.Stocks.Commands.CreateStock;

public sealed record CreateStockCommand(Guid ProductId, int CountOfProduct)
    : IRequest<Stock>;