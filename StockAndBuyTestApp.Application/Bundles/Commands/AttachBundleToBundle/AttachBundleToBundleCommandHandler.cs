using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.Entites;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;

namespace StockAndBuyTestApp.Application.Bundles.Commands.AttachBundleToBundle;

public class AttachBundleToBundleCommandHandler : IRequestHandler<BundleToBundleAttachmentCommand, Bundle>
{
    private readonly IBundleRepository _bundleRepository;
    private readonly IBundleToBundleRepository _bundleToBundleRepository;
    public AttachBundleToBundleCommandHandler(IBundleRepository bundleRepository, IBundleToBundleRepository bundleToBundleRepository)
    {
        _bundleRepository = bundleRepository;
        _bundleToBundleRepository = bundleToBundleRepository;
    }

    public async Task<Bundle> Handle(BundleToBundleAttachmentCommand request, CancellationToken cancellationToken)
    {
        var bundleId = BundleId.Create(request.BundleId);
        Bundle? existedBundle = await _bundleRepository.GetById(bundleId);
        if (existedBundle is null)
        {
            throw new Exception($"There is not bundle with id: {bundleId.Value} exist");
        }
        
        var ids = request.Bundles
            .Select(p => BundleId.Create(p.ChildBundleId))
            .ToList();
        
        var existingCount = await _bundleRepository.CountByIds(ids);
        if (existingCount != ids.Count)
        {
            throw new Exception("Some bundle IDs do not exist");
        }

        var bundleToBundleRelations = request.Bundles
            .Select(b =>
                BundleToBundleRelationship.Create(BundleId.Create(b.ChildBundleId),
                    BundleId.Create(request.BundleId), b.Count))
            .ToList();

        await _bundleToBundleRepository.AddRange(bundleToBundleRelations);
        existedBundle.AddBundleRelationshipRange(bundleToBundleRelations);
            
        var updateBundle = await _bundleRepository.Update(existedBundle);

        return updateBundle;
    }
}