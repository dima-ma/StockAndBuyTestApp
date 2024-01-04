using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Repositories;

public class BundleToBundleRepository : IBundleToBundleRepository
{
    private readonly StockAndBuyDbContext _context;

    public BundleToBundleRepository(StockAndBuyDbContext context)
    {
        _context = context;
    }

    public async Task AddRange(List<BundleToBundleRelationship> bundleToBundleRelations)
    {
        await _context.BundleRelationships.AddRangeAsync(bundleToBundleRelations);
        await _context.SaveChangesAsync();
    }

    public async Task<List<BundleInBundleDetails>> GetBundleDetailsForBundle(BundleId bundleId)
    {
        var result = new List<BundleInBundleDetails>();

        var bundleToBundleRelationships = await _context.BundleRelationships
            .Where(btb => btb.ParentBundleId == bundleId)
            .ToListAsync();

        foreach (var bundleToBundleRelationship in bundleToBundleRelationships)
        {
            var bundle = await _context.Bundles
                .FirstOrDefaultAsync(b => b.Id == bundleToBundleRelationship.ChildBundleId);

            if (bundle is null) continue;
            
            var childBundleDetails =
                await GetBundleDetailsForBundle(bundleToBundleRelationship.ChildBundleId);
            
            result.Add(new BundleInBundleDetails(
                bundle.Id.Value,
                bundle.Name,
                bundleToBundleRelationship.QuantityNeeded,
                bundle.Description,
                await GetProductDetailsForBundle(bundle.Id),
                childBundleDetails
            ));
        }

        return result;
    }
    
    private Task<List<ProductInBundleDetails>> GetProductDetailsForBundle(BundleId bundleId)
        =>  _context
            .BundleToProductRelationships
            .Where(bpr => bpr.BundleId == bundleId)
            .Join(_context.Products,
                bpr => bpr.ProductId,
                p => p.Id,
                (bpr, p)
                    => new ProductInBundleDetails(p.Id.Value, p.Name, bpr.QuantityNeeded))
            .ToListAsync();
}