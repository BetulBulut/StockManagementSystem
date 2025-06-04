using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.ApiResponse;
using Application.Services;

[ApiController]
[Route("api/[controller]")]
public class StockTypeController : ControllerBase
{
    private readonly StockTypeService _stockTypeService;

    public StockTypeController(StockTypeService stockTypeService)
    {
        _stockTypeService = stockTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<StockTypeResponse>>>> GetAll()
    {
        var result = await _stockTypeService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateStockTypeRequest request)
    {
        var result = await _stockTypeService.CreateAsync(request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateStockTypeRequest request)
    {
        var result = await _stockTypeService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpPatch("{id}/toggle-active")]
    public async Task<ActionResult<ApiResponse>> ToggleActive(int id)
    {
        var result = await _stockTypeService.ToggleActiveAsync(id);
        return Ok(result);
    }
}