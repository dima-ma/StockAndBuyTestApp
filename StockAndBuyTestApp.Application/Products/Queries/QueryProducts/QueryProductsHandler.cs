using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Product;

namespace StockAndBuyTestApp.Application.Products.Queries.QueryProducts;

public class QueryProductsHandler : IRequestHandler<QueryProducts, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public QueryProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(QueryProducts request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllProducts();
        return products;
    }
}