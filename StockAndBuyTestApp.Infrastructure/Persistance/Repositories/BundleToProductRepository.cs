using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.ValueObjects;

namespace StockAndBuyTestApp.Infrastructure.Persistance.Repositories;

public class BundleToProductRepository : IBundleToProductRepository
{
    private readonly StockAndBuyDbContext _context;

    public BundleToProductRepository(StockAndBuyDbContext context)
    {
        _context = context;
    }

    public async Task Add(BundleToProductRelationship bundleProductRelation)
    {
        await _context.BundleToProductRelationships.AddAsync(bundleProductRelation);
        await _context.SaveChangesAsync();
    }

    public Task<BundleToProductRelationship?> GetById(BundleToProductRelationshipId relationshipId)
        => _context
            .BundleToProductRelationships
            .AsNoTracking()
            .FirstOrDefaultAsync(rel => rel.Id == relationshipId);

    public async Task AddRange(List<BundleToProductRelationship> bundleProductRelations)
    {
        await _context.BundleToProductRelationships.AddRangeAsync(bundleProductRelations);
        await _context.SaveChangesAsync();
    }
}