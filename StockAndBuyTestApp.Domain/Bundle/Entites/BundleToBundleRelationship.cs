using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Models;

namespace StockAndBuyTestApp.Domain.Bundle.Entites;

public sealed class BundleToBundleRelationship : Entity<BundleToBundleRelationshipId>
{
    public BundleId ParentBundleId { get; private set; }
    public BundleId ChildBundleId { get; private set; }
    public int QuantityNeeded { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private BundleToBundleRelationship(BundleToBundleRelationshipId id, int quantityNeeded, BundleId childBundleId,
        BundleId parentBundleId, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        QuantityNeeded = quantityNeeded;
        ChildBundleId = childBundleId;
        ParentBundleId = parentBundleId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static BundleToBundleRelationship Create(BundleId childBundleId, BundleId parentId, int quantityNeeded)
        => new(BundleToBundleRelationshipId.CreateUnique(), quantityNeeded, childBundleId, parentId,
            DateTime.Now, DateTime.Now);
}