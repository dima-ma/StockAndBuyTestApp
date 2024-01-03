using StockAndBuyTestApp.Domain.Product;

namespace StockAndBuyTestApp.Application.Common.Interfaces.Persistance;

public interface IProductRepository
{
    void Add(Product product);
}