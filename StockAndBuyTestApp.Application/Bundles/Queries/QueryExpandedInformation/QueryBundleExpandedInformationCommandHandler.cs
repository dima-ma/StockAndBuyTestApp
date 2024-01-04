using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;

public class QueryBundleExpandedInformationCommandHandler
    : IRequestHandler<QueryBundleExpandedInformationCommand, QueryBundleExpandedInformationResponse>
{
    private readonly IBundleRepository _bundleRepository;
    private readonly IBundleToProductRepository _bundleToProductRepository;
    
    public QueryBundleExpandedInformationCommandHandler(IBundleRepository bundleRepository, IBundleToProductRepository bundleToProductRepository)
    {
        _bundleRepository = bundleRepository;
        _bundleToProductRepository = bundleToProductRepository;
    }

    public async Task<QueryBundleExpandedInformationResponse> Handle(QueryBundleExpandedInformationCommand request,
        CancellationToken cancellationToken)
    {
        BundleId bundleId = BundleId.Create(request.BundleId);
        var bundle = await _bundleRepository.GetById(bundleId);
        if (bundle is null)
        {
            throw new Exception($"There is not bundle with id: {bundleId.Value} exist");
        }

        List<ProductInBundleDetails> productDetails = 
            await _bundleToProductRepository.GetProductDetailsForBundle(bundleId);
        
        return new QueryBundleExpandedInformationResponse(bundle.Id.Value, bundle.Name, bundle.Description,
            bundle.CreatedDateTime, bundle.UpdatedDateTime, productDetails);
    }
}