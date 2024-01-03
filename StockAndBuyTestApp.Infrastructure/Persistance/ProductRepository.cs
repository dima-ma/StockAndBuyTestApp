using System.Net.Http.Headers;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Product;

namespace StockAndBuyTestApp.Infrastructure.Persistance;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new();
    public void Add(Product product)
    {
        _products.Add(product);
    }
}