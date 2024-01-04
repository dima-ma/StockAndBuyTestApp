using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Bundle.ValueObjects;

public sealed class BundleToBundleRelationshipId : ValueObject
{
    public Guid Value { get; private set; }

    private BundleToBundleRelationshipId(Guid value)
    {
        Value = value;
    }

    public static BundleToBundleRelationshipId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static BundleToBundleRelationshipId Create(Guid value) => new(value);
}