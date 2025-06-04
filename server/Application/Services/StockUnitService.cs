using StockManagementSystem.Application.Interfaces;
using StockManagementSystem.Application.UnitOfWork;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.ApiResponse;
using StockManagementSystem.Domain.Messages;
using AutoMapper;

namespace Application.Services
{
    public class StockUnitService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StockUnitService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<StockUnitResponse>>> GetAllAsync()
        {
            var list = (await _uow.StockUnits.GetAllAsync()).Where(x => x.IsActive).ToList();
            var response = _mapper.Map<List<StockUnitResponse>>(list);
            return new ApiResponse<List<StockUnitResponse>>(response) { Message = Messages.Success };
        }

        public async Task<ApiResponse> CreateAsync(StockUnitRequest dto)
        {
            if (await _uow.StockUnits.ExistsByCodeAsync(dto.Code))
                return new ApiResponse(Messages.StockUnitAlreadyExists);

            var entity = _mapper.Map<StockUnit>(dto);
            await _uow.StockUnits.AddAsync(entity);
            await _uow.Complete();
            return new ApiResponse() { Message = Messages.Success };
        }

        public async Task<ApiResponse> UpdateAsync(UpdateStockUnitRequest dto)
        {
            var entity = await _uow.StockUnits.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(Messages.NotFound);
            if (!entity.IsActive)
                return new ApiResponse(Messages.NotActive);

            _mapper.Map(dto, entity);
            await _uow.StockUnits.UpdateAsync(entity);
            await _uow.Complete();
            return new ApiResponse() { Message = Messages.Success };
        }

        public async Task<ApiResponse> ToggleActiveAsync(int id)
        {
            var entity = await _uow.StockUnits.GetByIdAsync(id);
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
