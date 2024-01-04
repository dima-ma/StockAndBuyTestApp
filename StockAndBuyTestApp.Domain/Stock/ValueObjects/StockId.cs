using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Domain.Stock.ValueObjects;

public sealed class StockId : ValueObject
{
    public Guid Value { get; private set; }

    private StockId(Guid value)
    {
        Value = value;
    }

    public static StockId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static StockId Create(Guid value) => new(value);
}