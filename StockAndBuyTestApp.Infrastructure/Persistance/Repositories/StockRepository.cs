using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Stock;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Repositories;

public class StockRepository : IStockRepository
{
    private readonly StockAndBuyDbContext _context;

    public StockRepository(StockAndBuyDbContext context)
    {
        _context = context;
    }

    public async Task Add(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();
    }

    public Task<List<Stock>> GetAllStocksRecords()
        => _context.Stocks.AsNoTracking().ToListAsync();
}