using MediatR;
using StockAndBuyTestApp.Domain.Bundle;

namespace StockAndBuyTestApp.Application.Bundles.Commands.CreateEmptyBundle;

public sealed record CreatEmptyBundleCommand(string Name, string Description)
    : IRequest<Bundle>;