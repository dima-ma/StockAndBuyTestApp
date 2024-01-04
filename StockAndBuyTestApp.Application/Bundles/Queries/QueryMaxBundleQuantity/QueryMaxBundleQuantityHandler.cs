using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryMaxBundleQuantity;

public class QueryMaxBundleQuantityHandler : IRequestHandler<QueryMaxBundleQuantity, int>
{
    private readonly IBundleRepository _bundleRepository;

    public QueryMaxBundleQuantityHandler(IBundleRepository bundleRepository)
    {
        _bundleRepository = bundleRepository;
    }

    public async Task<int> Handle(QueryMaxBundleQuantity request, CancellationToken cancellationToken)
    {
        int count = await _bundleRepository.GetMaxBundleQuantity(BundleId.Create(request.BundleId));
        return count;
    }
}