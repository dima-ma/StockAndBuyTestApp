using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StockAndBuyDbContext _context;

    public ProductRepository(StockAndBuyDbContext context)
    {
        _context = context;
    }

    public async Task Add(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public Task<List<Product>> GetAllProducts()
        => _context
            .Products
            .AsNoTracking()
            .ToListAsync();

    public Task<bool> AnyWithId(ProductId productId)
        => _context.Products.AnyAsync(p => p.Id == productId);

    public Task<Product?> GetById(ProductId relationshipProductId)
        => _context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == relationshipProductId);

    public Task<int> CountByIds(List<ProductId> ids)
        => _context.Products.CountAsync(d => ids.Contains(d.Id));
}