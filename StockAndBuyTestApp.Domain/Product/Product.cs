using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Domain.Product;

public class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    
    private readonly List<BundleToProductRelationship> _bundleItems = new();
    public IReadOnlyList<BundleToProductRelationship> BundleItems => _bundleItems.AsReadOnly();

    private Product(ProductId id, string name, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Product Create(string name)
        => new(ProductId.CreateUnique(), name, DateTime.Now, DateTime.Now);
}