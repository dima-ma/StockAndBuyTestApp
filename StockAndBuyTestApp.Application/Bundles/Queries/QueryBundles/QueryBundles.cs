using MediatR;
using StockAndBuyTestApp.Domain.Bundle;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryBundles;

public sealed record QueryBundles() : IRequest<List<Bundle>>;