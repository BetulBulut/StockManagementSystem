using StockManagementSystem.Domain.Entities;

namespace StockManagementSystem.Application.Interfaces
{
    public interface IStockUnitRepository
    {
        Task<List<StockUnit>> GetAllAsync();
        Task<StockUnit?> GetByIdAsync(int id);
        Task AddAsync(StockUnit entity);
        Task UpdateAsync(StockUnit entity);
        Task<bool> ExistsByCodeAsync(string code);
    }
}
