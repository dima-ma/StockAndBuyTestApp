using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Bundle.ValueObjects;

public sealed class BundleId : ValueObject
{
    public Guid Value { get; private set; }

    private BundleId(Guid value)
    {
        Value = value;
    }

    public static BundleId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}