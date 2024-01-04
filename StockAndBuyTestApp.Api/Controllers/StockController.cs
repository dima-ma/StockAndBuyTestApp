using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockAndBuyTestApp.Application.Stocks.Commands.CreateStock;
using StockAndBuyTestApp.Application.Stocks.Queries.QueryStocks;
using StockAndBuyTestApp.Contracts.Stock;

namespace StockAndBuyTestApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _mediatr;

    public StockController(IMapper mapper, ISender mediatr)
    {
        _mapper = mapper;
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStockInformation()
    {
        var stockRecords = await _mediatr.Send(new QueryStocks());
        var mapped = _mapper.Map<List<StockResponse>>(stockRecords);
        return Ok(mapped);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStock(CreateStockRequest request)
    {
        var command = _mapper.Map<CreateStockCommand>(request);
        var filledStockData = await _mediatr.Send(command);
        return Ok(_mapper.Map<StockResponse>(filledStockData));    
    }
}