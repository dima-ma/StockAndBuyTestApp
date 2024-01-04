using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

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

    public Task<int> CountByIds(List<BundleId> ids)
        => _context.Bundles.CountAsync(b => ids.Contains(b.Id));

    public async Task<int> GetMaxBundleQuantity(BundleId bundleId)
    {
        var bundleRelations = await _context.BundleToProductRelationships
            .Where(bpr => bpr.BundleId == bundleId)
            .ToListAsync();

        var minQuantity = int.MaxValue;

        foreach (var relation in bundleRelations)
        {
            var stockQuantity = await GetQuantity(relation.ProductId);
            var requiredQuantity = relation.QuantityNeeded;
            minQuantity = Math.Min(minQuantity, stockQuantity / requiredQuantity);
        }

        var childBundles = await _context.BundleRelationships
            .Where(btb => btb.ParentBundleId == bundleId)
            .ToListAsync();

        foreach (var childBundle in childBundles)
        {
            var childBundleQuantity = await GetMaxBundleQuantity(childBundle.ChildBundleId);
            var requireCount = childBundle.QuantityNeeded;
            minQuantity = Math.Min(minQuantity, childBundleQuantity / requireCount);
        }

        return minQuantity == int.MaxValue ? 0 : minQuantity;
    }

    private async Task<int> GetQuantity(ProductId relationProductId)
        => (await _context.Stocks.FirstAsync(s => s.ProductId == relationProductId)).Count;
}