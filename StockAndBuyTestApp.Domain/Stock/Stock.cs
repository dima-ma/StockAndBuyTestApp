using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Product.ValueObjects;
using StockAndBuyTestApp.Domain.Stock.ValueObjects;

namespace StockAndBuyTestApp.Domain.Stock;

public class Stock : AggregateRoot<StockId>
{
    public ProductId ProductId { get; private set; }
    public int Count { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Stock(StockId id, ProductId productId, int count, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        ProductId = productId;
        Count = count;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Stock Create(ProductId productId, int count)
        => new(StockId.CreateUnique(), productId, count, DateTime.Now, DateTime.Now);
}