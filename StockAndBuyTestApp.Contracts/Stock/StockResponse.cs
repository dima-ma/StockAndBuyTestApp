namespace StockAndBuyTestApp.Contracts.Stock;

public record StockResponse(Guid Id, Guid ProductId, int Count, DateTime CreatedDateTime, DateTime UpdatedDateTime);