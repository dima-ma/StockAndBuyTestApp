using StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;
using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Application.Common.Interfaces.Persistance;

public interface IBundleToBundleRepository
{
    Task AddRange(List<BundleToBundleRelationship> bundleToBundleRelations);
    Task<List<BundleInBundleDetails>> GetBundleDetailsForBundle(BundleId bundleId);
}