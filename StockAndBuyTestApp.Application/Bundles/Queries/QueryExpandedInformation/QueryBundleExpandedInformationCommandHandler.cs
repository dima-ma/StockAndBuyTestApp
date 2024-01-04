using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;

public class QueryBundleExpandedInformationCommandHandler
    : IRequestHandler<QueryBundleExpandedInformationCommand, QueryBundleExpandedInformationResponse>
{
    private readonly IBundleRepository _bundleRepository;
    private readonly IBundleToProductRepository _bundleToProductRepository;
    private readonly IBundleToBundleRepository _bundleToBundleRepository;
    public QueryBundleExpandedInformationCommandHandler(IBundleRepository bundleRepository, IBundleToProductRepository bundleToProductRepository, IBundleToBundleRepository bundleToBundleRepository)
    {
        _bundleRepository = bundleRepository;
        _bundleToProductRepository = bundleToProductRepository;
        _bundleToBundleRepository = bundleToBundleRepository;
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
        
        List<BundleInBundleDetails> bundleDetails =
            await _bundleToBundleRepository.GetBundleDetailsForBundle(bundleId);
        
        
        return new QueryBundleExpandedInformationResponse(bundle.Id.Value, bundle.Name, bundle.Description,
            bundle.CreatedDateTime, bundle.UpdatedDateTime, 
            productDetails, bundleDetails);
    }
}