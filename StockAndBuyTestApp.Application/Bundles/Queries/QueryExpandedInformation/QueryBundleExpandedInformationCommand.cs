using MediatR;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;

public sealed record ProductInBundleDetails(Guid Id, string Name, int Count);

public sealed record BundleInBundleDetails(
    Guid Id,
    string Name,
    int Count,
    string Description,
    List<ProductInBundleDetails> Products,
    List<BundleInBundleDetails> ChildBundles);

public sealed record QueryBundleExpandedInformationResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime,
    List<ProductInBundleDetails> Products,
    List<BundleInBundleDetails> ChildBundles);

public sealed record QueryBundleExpandedInformationCommand(Guid BundleId)
    : IRequest<QueryBundleExpandedInformationResponse>;