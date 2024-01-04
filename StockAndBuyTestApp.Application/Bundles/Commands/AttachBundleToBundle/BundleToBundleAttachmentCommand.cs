using MediatR;
using StockAndBuyTestApp.Application.Bundles.Commands.AttachProductsToBundle;
using StockAndBuyTestApp.Domain.Bundle;

namespace StockAndBuyTestApp.Application.Bundles.Commands.AttachBundleToBundle;

public sealed record BundleToBundleAttachment(Guid ChildBundleId, int Count);
public sealed record BundleToBundleAttachmentCommand(Guid BundleId, List<BundleToBundleAttachment> Bundles) : IRequest<Bundle>;