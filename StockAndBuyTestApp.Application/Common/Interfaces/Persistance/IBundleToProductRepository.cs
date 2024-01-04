using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.ValueObjects;

namespace StockAndBuyTestApp.Application.Common.Interfaces.Persistance;

public interface IBundleToProductRepository
{
    Task Add(BundleToProductRelationship bundleProductRelation);
    Task<BundleToProductRelationship?> GetById(BundleToProductRelationshipId relationshipId);
    Task AddRange(List<BundleToProductRelationship> bundleProductRelations);
}