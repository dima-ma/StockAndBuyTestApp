using StockAndBuyTestApp.Domain.Stock;

namespace StockAndBuyTestApp.Application.Common.Interfaces.Persistance;

public interface IStockRepository
{
    Task Add(Stock stock);
    Task<List<Stock>> GetAllStocksRecords();
}