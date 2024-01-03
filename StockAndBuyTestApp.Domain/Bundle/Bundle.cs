using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Bundle;

public sealed class Bundle : AggregateRoot<BundleId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    
    private readonly List<BundleToBundleRelationship> _bundleItems = new();
    public IReadOnlyList<BundleToBundleRelationship> BundleItems => _bundleItems.AsReadOnly();

    private readonly List<BundleToProductRelationship> _productItems = new();
    public IReadOnlyList<BundleToProductRelationship> ProductItems => _productItems.AsReadOnly();

    private Bundle(BundleId id, string name, string description, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bundle Create(string name, string description)
        => new(BundleId.CreateUnique(), name, description, DateTime.Now, DateTime.Now);
}