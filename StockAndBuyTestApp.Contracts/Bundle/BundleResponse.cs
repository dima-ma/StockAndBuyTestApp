namespace StockAndBuyTestApp.Contracts.Bundle;

public record BundleResponse(Guid Id, string Name, string Description, DateTime CreatedDateTime, DateTime UpdatedDateTime,
    List<string> ChildBundlesIds, List<string> ChildProductIds);