using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Application.UnitOfWork;
using StockManagementSystem.Domain.ApiResponse;
using StockManagementSystem.Domain.Messages;
using AutoMapper;
namespace Application.Services;
public class StockTypeService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public StockTypeService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<StockTypeResponse>>> GetAllAsync()
    {
        var list = (await _uow.StockTypes.GetAllAsync()).Where(x => x.IsActive).ToList();
        var response = _mapper.Map<List<StockTypeResponse>>(list);
        return new ApiResponse<List<StockTypeResponse>>(response) { Message = Messages.Success };
    }

    public async Task<ApiResponse> CreateAsync(CreateStockTypeRequest dto)
    {
        if (await _uow.StockTypes.ExistsByNameAsync(dto.Name))
            return new ApiResponse(Messages.StockTypeAlreadyExists);

        var entity = _mapper.Map<StockType>(dto);
        await _uow.StockTypes.AddAsync(entity);
        await _uow.Complete();
        return new ApiResponse() { Message = Messages.Success };
    }

    public async Task<ApiResponse> UpdateAsync(UpdateStockTypeRequest dto)
    {
        var existing = await _uow.StockTypes.GetByIdAsync(dto.Id);
        if (existing == null)
            return new ApiResponse(Messages.NotFound);
        if (!existing.IsActive)
            return new ApiResponse(Messages.NotActive);

        _mapper.Map(dto, existing);
        await _uow.StockTypes.UpdateAsync(existing);
        await _uow.Complete();
        return new ApiResponse() { Message = Messages.Success };
    }

    public async Task<ApiResponse> ToggleActiveAsync(int id)
    {
        var existing = await _uow.StockTypes.GetByIdAsync(id);
        if (existing == null)
            return new ApiResponse(Messages.NotFound);
        if (!existing.IsActive)
            return new ApiResponse(Messages.NotActive);

        existing.IsActive = !existing.IsActive;
        await _uow.StockTypes.UpdateAsync(existing);
        await _uow.Complete();
        return new ApiResponse() { Message = Messages.Success };
    }
}
