using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockAndBuyTestApp.Application.Products.Commands.CreateProduct;
using StockAndBuyTestApp.Application.Products.Queries.QueryProducts;
using StockAndBuyTestApp.Contracts.Products;

namespace StockAndBuyTestApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    
    public ProductsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new QueryProducts());
        var mapped = _mapper.Map<List<ProductResponse>>(products);
        return Ok(mapped);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);
        var createMenuResult = await _mediator.Send(command);
        return Ok(_mapper.Map<ProductResponse>(createMenuResult));
    }
}