namespace StockAndBuyTestApp.Contracts.Products;

public record ProductResponse(Guid Id, string Name, DateTime CreatedDateTime, DateTime UpdatedDateTime);