using MediatR;
using StockAndBuyTestApp.Domain.Product;

namespace StockAndBuyTestApp.Application.Products.Queries.QueryProducts;

public sealed record QueryProducts() : IRequest<List<Product>>;