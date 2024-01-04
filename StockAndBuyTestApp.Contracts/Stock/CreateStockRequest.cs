namespace StockAndBuyTestApp.Contracts.Stock;

public record CreateStockRequest(Guid ProductId, int CountOfProduct);