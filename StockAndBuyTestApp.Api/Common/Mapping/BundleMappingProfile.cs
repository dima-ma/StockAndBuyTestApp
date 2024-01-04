using AutoMapper;
using StockAndBuyTestApp.Application.Bundles.Commands.AttachBundleToBundle;
using StockAndBuyTestApp.Application.Bundles.Commands.AttachProductsToBundle;
using StockAndBuyTestApp.Application.Bundles.Commands.CreateEmptyBundle;
using StockAndBuyTestApp.Contracts.Bundle;
using StockAndBuyTestApp.Domain.Bundle;
using StockAndBuyTestApp.Domain.Bundle.ValueObjects;
using StockAndBuyTestApp.Domain.Common.ValueObjects;

namespace StockAndBuyTestApp.Api.Common.Mapping;

public class BundleMappingProfile : Profile
{
    public BundleMappingProfile()
    {
        CreateMap<CreateEmptyBundleRequest, CreatEmptyBundleCommand>().ReverseMap();
        CreateMap<BundleId, Guid>().ConvertUsing(pid => pid.Value);
        CreateMap<BundleToBundleRelationshipId, Guid>().ConvertUsing(pid => pid.Value);
        CreateMap<BundleToProductRelationshipId, Guid>().ConvertUsing(pid => pid.Value);
        CreateMap<Bundle, BundleResponse>()
            .ConstructUsing(src => new BundleResponse(
                src.Id.Value,
                src.Name,
                src.Description,
                src.CreatedDateTime,
                src.UpdatedDateTime,
                src.BundleItemsIds.Select(id => id.Value.ToString()).ToList(),
                src.ProductItemsIds.Select(id => id.Value.ToString()).ToList()
            ));


        CreateMap<(AttachProductsToBundleRequest request, Guid id), ProductBundleAttachmentCommand>()
            .ConstructUsing(src => new ProductBundleAttachmentCommand(
                src.id,
                src.request.ProductToBundleRequests.Select(a =>
                    new ProductBundleAttachment(a.ProductId, a.Count)).ToList()));

        CreateMap<(AttachBundleToBundleRequest request, Guid id), BundleToBundleAttachmentCommand>()
            .ConstructUsing(src => new BundleToBundleAttachmentCommand(
                src.id,
                src.request.BundleToBundleRequests.Select(a =>
                    new BundleToBundleAttachment(a.BundleId, a.Count)).ToList()));
    }
}