using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Application.Common.Interfaces.Persistance;

public interface IBundleRepository
{
    Task Add(Bundle bundle);
    Task<List<Bundle>> GetAllBundles();
    Task<Bundle?> GetById(BundleId bundleId);
    Task<Bundle> Update(Bundle existedBundle);
}