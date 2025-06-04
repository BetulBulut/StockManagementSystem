using Microsoft.AspNetCore.Mvc;
using Application.Services;
using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.ApiResponse;

namespace StockManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockUnitController : ControllerBase
    {
        private readonly StockUnitService _stockUnitService;

        public StockUnitController(StockUnitService stockUnitService)
        {
            _stockUnitService = stockUnitService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<StockUnitResponse>>>> GetAll()
        {
            var result = await _stockUnitService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] StockUnitRequest request)
        {
            var result = await _stockUnitService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateStockUnitRequest request)
        {
            var result = await _stockUnitService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpPatch("{id}/toggle-active")]
        public async Task<ActionResult<ApiResponse>> ToggleActive(int id)
        {
            var result = await _stockUnitService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}