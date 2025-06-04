using StockManagementSystem.Domain.Entities;

namespace StockManagementSystem.Application.Interfaces;

public interface IStockTypeRepository
{
    Task<List<StockType>> GetAllAsync();
    Task<StockType?> GetByIdAsync(int id);
    Task AddAsync(StockType entity);
    Task UpdateAsync(StockType entity);
    Task<bool> ExistsByNameAsync(string name);
}

