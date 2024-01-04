namespace StockAndBuyTestApp.Contracts.Bundle;

public sealed record ProductToBundleRequest(Guid ProductId, int Count);
public sealed record AttachProductsToBundleRequest(List<ProductToBundleRequest> ProductToBundleRequests);