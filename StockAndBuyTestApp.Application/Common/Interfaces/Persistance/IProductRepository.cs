using StockAndBuyTestApp.Domain.Product;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Application.Common.Interfaces.Persistance;

public interface IProductRepository
{
    Task Add(Product product);
    Task<List<Product>> GetAllProducts();
    Task<bool> AnyWithId(ProductId productId);
    Task<Product?> GetById(ProductId relationshipProductId);
    Task<int> CountByIds(List<ProductId> ids);
}