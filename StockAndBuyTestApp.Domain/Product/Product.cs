using StockAndBuyTestApp.Domain.Common.Models;
using StockAndBuyTestApp.Domain.Product.Events;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Domain.Product;

public class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Product(ProductId id, string name, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Product()
    {
    }

    public static Product Create(string name)
    {
        var product = new Product(ProductId.CreateUnique(), name, DateTime.Now, DateTime.Now);
        
        product.AddDomainEvent(new ProductCreated(product));
        
        return product;
    }
}