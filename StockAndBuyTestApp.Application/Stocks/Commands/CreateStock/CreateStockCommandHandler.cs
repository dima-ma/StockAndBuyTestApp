using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Product.ValueObjects;
using StockAndBuyTestApp.Domain.Stock;

namespace StockAndBuyTestApp.Application.Stocks.Commands.CreateStock;

public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, Stock>
{
    private readonly IStockRepository _stockRepository;
    private readonly IProductRepository  _productRepository;
    public CreateStockCommandHandler(IStockRepository stockRepository, IProductRepository productRepository)
    {
        _stockRepository = stockRepository;
        _productRepository = productRepository;
    }

    public async Task<Stock> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        var productId = ProductId.Create(request.ProductId);
        var isProductExist = await _productRepository.AnyWithId(productId);
        if (isProductExist == false)
        {
            throw new Exception("Invalid product Id entered");
        }
        
        var stock = Stock.Create(productId, request.CountOfProduct);
        await _stockRepository.Add(stock);
        return stock;
    }
}