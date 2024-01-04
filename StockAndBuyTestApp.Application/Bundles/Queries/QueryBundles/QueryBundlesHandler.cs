using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryBundles;

public class QueryBundlesHandler : IRequestHandler<QueryBundles, List<Bundle>>
{
    private readonly IBundleRepository _bundleRepository;

    public QueryBundlesHandler(IBundleRepository bundleRepository)
    {
        _bundleRepository = bundleRepository;
    }

    public async Task<List<Bundle>> Handle(QueryBundles request, CancellationToken cancellationToken)
    {
        var bundles = await _bundleRepository.GetAllBundles();
        return bundles;
    }
}