using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Repositories;

public class BundleRepository : IBundleRepository
{
    private readonly StockAndBuyDbContext _context;

    public BundleRepository(StockAndBuyDbContext context)
    {
        _context = context;
    }

    public async Task Add(Bundle bundle)
    {
        await _context.Bundles.AddAsync(bundle);
        await _context.SaveChangesAsync();
    }

    public Task<List<Bundle>> GetAllBundles()
        => _context.Bundles.AsNoTracking().ToListAsync();

    public Task<Bundle?> GetById(BundleId bundleId)
        => _context.Bundles
            .FirstOrDefaultAsync(b => b.Id == bundleId);

    public async Task<Bundle> Update(Bundle existedBundle)
    {
        var entry = _context.Bundles.Update(existedBundle);
        await _context.SaveChangesAsync();
        
        return entry.Entity;
    }
}