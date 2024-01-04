using MediatR;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryMaxBundleQuantity;

public sealed record QueryMaxBundleQuantity(Guid BundleId) : IRequest<int>;