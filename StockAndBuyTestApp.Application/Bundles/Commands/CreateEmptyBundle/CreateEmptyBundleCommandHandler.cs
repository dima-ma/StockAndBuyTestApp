using MediatR;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Domain.Bundle;

namespace StockAndBuyTestApp.Application.Bundles.Commands.CreateEmptyBundle;

public class CreateEmptyBundleCommandHandler : IRequestHandler<CreatEmptyBundleCommand, Bundle>
{
    private readonly IBundleRepository _bundleRepository;

    public CreateEmptyBundleCommandHandler(IBundleRepository bundleRepository)
    {
        _bundleRepository = bundleRepository;
    }

    public async Task<Bundle> Handle(CreatEmptyBundleCommand request, CancellationToken cancellationToken)
    {
        var bundle = Bundle.Create(request.Name, request.Description);

        await _bundleRepository.Add(bundle);
        
        return bundle;
    }
}