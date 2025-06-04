using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Application.UnitOfWork;
using StockManagementSystem.Domain.ApiResponse;
using StockManagementSystem.Domain.Enums;
using StockManagementSystem.Domain.Messages;
using AutoMapper;

namespace Application.Services
{
    public class StockService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StockService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<StockResponse>>> GetAllAsync()
        {
            var list = (await _uow.Stocks.GetAllAsync()).Where(x => x.IsActive).ToList();
            var response = _mapper.Map<List<StockResponse>>(list);
            return new ApiResponse<List<StockResponse>>(response) { Message = Messages.Success };
        }

        public async Task<ApiResponse> CreateAsync(CreateStockRequest dto)
        {
            var entity = _mapper.Map<Stock>(dto);
            await _uow.Stocks.AddAsync(entity);
            await _uow.Complete();
            return new ApiResponse() { Message = Messages.Success };
        }

        public async Task<ApiResponse> UpdateAsync(UpdateStockRequest dto)
        {
            var entity = await _uow.Stocks.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(Messages.NotFound);
            if (!entity.IsActive)
                return new ApiResponse(Messages.NotActive);

            _mapper.Map(dto, entity);
            await _uow.Stocks.UpdateAsync(entity);
            await _uow.Complete();
            return new ApiResponse() { Message = Messages.Success };
        }

        public async Task<ApiResponse> ToggleActiveAsync(int id)
        {
            var entity = await _uow.Stocks.GetByIdAsync(id);
            if (entity == null)
                return new ApiResponse(Messages.NotFound);
            if (!entity.IsActive)
                return new ApiResponse(Messages.NotActive);

            entity.IsActive = !entity.IsActive;
            await _uow.Complete();
            return new ApiResponse() { Message = Messages.Success };
        }
    }
}
