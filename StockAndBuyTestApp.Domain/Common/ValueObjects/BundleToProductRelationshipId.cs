using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Common.ValueObjects;

public sealed class BundleToProductRelationshipId : ValueObject
{
    public Guid Value { get; private set; }

    private BundleToProductRelationshipId(Guid value)
    {
        Value = value;
    }

    public static BundleToProductRelationshipId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}