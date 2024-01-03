using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Product.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; private set; }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}