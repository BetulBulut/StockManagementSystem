using StockManagementSystem.Domain.Entities;

namespace StockManagementSystem.Application.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task AddAsync(Stock entity);
        Task UpdateAsync(Stock entity);
    }
}
