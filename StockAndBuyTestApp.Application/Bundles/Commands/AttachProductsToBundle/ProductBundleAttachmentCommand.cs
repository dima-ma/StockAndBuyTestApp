using MediatR;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.Entites;

namespace StockAndBuyTestApp.Application.Bundles.Commands.AttachProductsToBundle;

public sealed record ProductBundleAttachment(Guid ProductId, int Count);
public sealed record ProductBundleAttachmentCommand(Guid BundleId, List<ProductBundleAttachment> Products) : IRequest<Bundle>;