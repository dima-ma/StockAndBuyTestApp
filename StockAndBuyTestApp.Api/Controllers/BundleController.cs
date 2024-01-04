using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockAndBuyTestApp.Application.Bundles.Commands.AttachBundleToBundle;
using StockAndBuyTestApp.Application.Bundles.Commands.AttachProductsToBundle;
using StockAndBuyTestApp.Application.Bundles.Commands.CreateEmptyBundle;
using StockAndBuyTestApp.Application.Bundles.Queries.QueryBundles;
using StockAndBuyTestApp.Application.Bundles.Queries.QueryExpandedInformation;
using StockAndBuyTestApp.Application.Bundles.Queries.QueryMaxBundleQuantity;
using StockAndBuyTestApp.Contracts.Bundle;

namespace StockAndBuyTestApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BundleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediatr;

    public BundleController(IMapper mapper, ISender mediatr)
    {
        _mapper = mapper;
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBundles()
    {
        var bundles = await _mediatr.Send(new QueryBundles());
        var mapped = _mapper.Map<List<BundleResponse>>(bundles);
        return Ok(mapped);
    }


    [HttpGet("{bundleId:guid}")]
    public async Task<IActionResult> GetExpandedInformation(Guid bundleId)
    {
        var bundleWithAllInformation = await _mediatr.Send(new QueryBundleExpandedInformationCommand(bundleId));
        return Ok(bundleWithAllInformation);
    }

    [HttpGet("MaxBundleQuantity/{bundleId:guid}")]
    public async Task<IActionResult> GetMaxBundleQuantity(Guid bundleId)
    {
        var count = await _mediatr.Send(new QueryMaxBundleQuantity(bundleId));
        return Ok(new { MaxBundleQuantity = count});
    }
    [HttpPost]
    public async Task<IActionResult> CreateBundle(CreateEmptyBundleRequest request)
    {
        var command = _mapper.Map<CreatEmptyBundleCommand>(request);
        var createdBundle = await _mediatr.Send(command);
        return Ok(_mapper.Map<BundleResponse>(createdBundle));
    }
    
    [HttpPut("attachProducts/{bundleId:guid}")]
    public async Task<IActionResult> AttachProductsToBundle(Guid bundleId, AttachProductsToBundleRequest request)
    {
        var command = _mapper.Map<ProductBundleAttachmentCommand>((request, bundleId));
        var updatedBundle = await _mediatr.Send(command);
        return Ok(_mapper.Map<BundleResponse>(updatedBundle));
    }
    
    [HttpPut("attachBundle/{bundleId:guid}")]
    public async Task<IActionResult> AttachBundleToBundle(Guid bundleId, AttachBundleToBundleRequest request)
    {
        var command = _mapper.Map<BundleToBundleAttachmentCommand>((request, bundleId));
        var updatedBundle = await _mediatr.Send(command);
        return Ok(_mapper.Map<BundleResponse>(updatedBundle));
    }
}