using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Product;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;

//TODO: Delete or refactor this query and handler
public sealed record QueryProd(Guid Id, string Name, int Count);
public sealed record QueryBundleExpandedInformationResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime,
    List<QueryProd> Products);

public sealed record QueryBundleExpandedInformationCommand(Guid BundleId)
    : IRequest<QueryBundleExpandedInformationResponse>;

public class QueryBundleExpandedInformationCommandHandler
    : IRequestHandler<QueryBundleExpandedInformationCommand, QueryBundleExpandedInformationResponse>
{
    private readonly IBundleRepository _bundleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IBundleToProductRepository _bundleToProductRepository;

    public QueryBundleExpandedInformationCommandHandler(IProductRepository productRepository,
        IBundleToProductRepository bundleToProductRepository, IBundleRepository bundleRepository)
    {
        _productRepository = productRepository;
        _bundleToProductRepository = bundleToProductRepository;
        _bundleRepository = bundleRepository;
    }

    public async Task<QueryBundleExpandedInformationResponse> Handle(QueryBundleExpandedInformationCommand request,
        CancellationToken cancellationToken)
    {
        var bundleId = BundleId.Create(request.BundleId);
        Bundle? existedBundle = await _bundleRepository.GetById(bundleId);
        if (existedBundle is null)
        {
            throw new Exception($"There is not bundle with id: {bundleId.Value} exist");
        }

        List<QueryProd> products = new();
        foreach (var relationshipId in existedBundle.ProductItemsIds)
        {
            BundleToProductRelationship? relationship = await
                _bundleToProductRepository.GetById(relationshipId);

            if (relationship is null) throw new InvalidOperationException();

            Product? product = await _productRepository.GetById(relationship.ProductId);

            if (product is null) throw new InvalidOperationException();

            products.Add(new QueryProd(product.Id.Value, product.Name, relationship.QuantityNeeded));
        }

        return new QueryBundleExpandedInformationResponse(
            bundleId.Value, existedBundle.Name, existedBundle.Description,
            existedBundle.CreatedDateTime, existedBundle.UpdatedDateTime,
            products);
    }
}