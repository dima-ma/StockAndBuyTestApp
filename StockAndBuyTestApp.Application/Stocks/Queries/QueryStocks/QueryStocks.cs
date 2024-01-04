using MediatR;
using StockAndBuyTestApp.Domain.Stock;

namespace StockAndBuyTestApp.Application.Stocks.Queries.QueryStocks;

public sealed record QueryStocks() : IRequest<List<Stock>>;