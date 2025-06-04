using Microsoft.AspNetCore.Mvc;
using Application.Services;
using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.ApiResponse;

namespace StockManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<StockResponse>>>> GetAll()
        {
            var result = await _stockService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateStockRequest request)
        {
            var result = await _stockService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateStockRequest request)
        {
            var result = await _stockService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpPatch("{id}/toggle-active")]
        public async Task<ActionResult<ApiResponse>> ToggleActive(int id)
        {
            var result = await _stockService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}