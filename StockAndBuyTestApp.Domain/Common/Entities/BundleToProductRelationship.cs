using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Common.ValueObjects;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Domain.Common.Entities;

public sealed class BundleToProductRelationship : Entity<BundleToProductRelationshipId>
{
    public BundleId BundleId { get; private set; }
    public ProductId ProductId { get; private set; }
    public int QuantityNeeded { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private BundleToProductRelationship(BundleToProductRelationshipId id, int quantityNeeded, ProductId productId,
        BundleId bundleId, DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        QuantityNeeded = quantityNeeded;
        ProductId = productId;
        BundleId = bundleId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static BundleToProductRelationship Create(ProductId childProductId, BundleId parentId, int quantityNeeded)
        => new(BundleToProductRelationshipId.CreateUnique(), quantityNeeded, childProductId, parentId,
            DateTime.Now, DateTime.Now);
}