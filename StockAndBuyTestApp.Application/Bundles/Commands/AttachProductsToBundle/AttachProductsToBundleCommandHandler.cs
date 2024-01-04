using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.Entities;
using StockAndBuyTestApp.Domain.Product.ValueObjects;

namespace StockAndBuyTestApp.Application.Bundles.Commands.AttachProductsToBundle;

public class AttachProductsToBundleCommandHandler : IRequestHandler<ProductBundleAttachmentCommand, Bundle>
{
    private readonly IBundleRepository _bundleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IBundleToProductRepository _bundleToProductRepository;

    public AttachProductsToBundleCommandHandler(IBundleRepository bundleRepository,
        IProductRepository productRepository, IBundleToProductRepository bundleToProductRepository)
    {
        _bundleRepository = bundleRepository;
        _productRepository = productRepository;
        _bundleToProductRepository = bundleToProductRepository;
    }

    public async Task<Bundle> Handle(ProductBundleAttachmentCommand request, CancellationToken cancellationToken)
    {
        var bundleId = BundleId.Create(request.BundleId);
        Bundle? existedBundle = await _bundleRepository.GetById(bundleId);
        if (existedBundle is null)
        {
            throw new Exception($"There is not bundle with id: {bundleId.Value} exist");
        }

        var ids = request.Products
            .Select(p => ProductId.Create(p.ProductId))
            .ToList();
        var existingCount = await _productRepository.CountByIds(ids);
        if (existingCount != ids.Count)
        {
            throw new Exception("Some product IDs do not exist");
        }

        var bundleProductRelations = request.Products
            .Select(p =>
                BundleToProductRelationship.Create(ProductId.Create(p.ProductId),
                    BundleId.Create(request.BundleId), p.Count))
            .ToList();
        await _bundleToProductRepository.AddRange(bundleProductRelations);
        existedBundle.AddProductRelationshipRange(bundleProductRelations);

        var updateBundle = await _bundleRepository.Update(existedBundle);

        return updateBundle;
    }
}