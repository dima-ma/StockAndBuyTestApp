using MediatR;
using StockAndBuyTestApp.Domain.Product;

namespace StockAndBuyTestApp.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name) 
    : IRequest<Product>;