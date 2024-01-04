namespace StockAndBuyTestApp.Contracts.Bundle;

public sealed record BundleToBundleRequest(Guid BundleId, int Count);
public sealed record AttachBundleToBundleRequest(List<BundleToBundleRequest> BundleToBundleRequests);