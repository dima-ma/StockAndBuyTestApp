using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Stock;

namespace StockAndBuyTestApp.Application.Stocks.Queries.QueryStocks;

public class QueryStocksHandler : IRequestHandler<QueryStocks, List<Stock>>
{
    private readonly IStockRepository _stockRepository;

    public QueryStocksHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<List<Stock>> Handle(QueryStocks request, CancellationToken cancellationToken)
    {
        var stocksRecords = await _stockRepository.GetAllStocksRecords();
        return stocksRecords;
    }
}