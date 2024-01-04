using MediatR;

namespace StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;

public sealed record ProductInBundleDetails(Guid Id, string Name, int Count);
public sealed record QueryBundleExpandedInformationResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime,
    List<ProductInBundleDetails> Products);

public sealed record QueryBundleExpandedInformationCommand(Guid BundleId)
    : IRequest<QueryBundleExpandedInformationResponse>;