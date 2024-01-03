namespace StockAndBuyTestApp.Contracts.Products;

public record ProductResponse(Guid Id, string Name, List<string> BundleIds,
    DateTime CreatedDateTime, DateTime UpdatedDateTime);