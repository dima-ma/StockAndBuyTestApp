using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Common.ValueObjects;

namespace StockAndBuyTestApp.Domain.Bundle;

public sealed class Bundle : AggregateRoot<BundleId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private readonly List<BundleToBundleRelationshipId> _bundleItemsIds = new();
    public IReadOnlyList<BundleToBundleRelationshipId> BundleItemsIds => _bundleItemsIds.AsReadOnly();

    private readonly List<BundleToProductRelationshipId> _productItemsIds = new();
    public IReadOnlyList<BundleToProductRelationshipId> ProductItemsIds => _productItemsIds.AsReadOnly();

    private Bundle(BundleId id, string name, string description, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Bundle()
    {
    }

    public static Bundle Create(string name, string description)
        => new(BundleId.CreateUnique(), name, description, DateTime.Now, DateTime.Now);


    public void AddProductRelationship(BundleToProductRelationship bundleProductRelation)
    {
        _productItemsIds.Add(bundleProductRelation.Id);
    }

    public void AddProductRelationshipRange(IEnumerable<BundleToProductRelationship> bundleProductRelations)
    {
        _productItemsIds.AddRange(bundleProductRelations.Select(p => p.Id));
    }
    public void AddBundleRelationship(BundleToBundleRelationship bundleProductRelation)
    {
        _bundleItemsIds.Add(bundleProductRelation.Id);
    }
    public void AddBundleRelationshipRange(IEnumerable<BundleToBundleRelationship> bundleToBundleRelations)
    {
       _bundleItemsIds.AddRange(bundleToBundleRelations.Select(p =>p.Id));
    }
}