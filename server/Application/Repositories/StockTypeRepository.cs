using StockManagementSystem.Application.Interfaces;
using StockManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.Application.Repositories;

public class StockTypeRepository : IStockTypeRepository
{
    private readonly AppDbContext _context;

    public StockTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StockType entity)
    {
        await _context.StockTypes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<StockType>> GetAllAsync()
    {
        return await _context.StockTypes.ToListAsync();
    }

    public async Task<StockType?> GetByIdAsync(int id)
    {
        return await _context.StockTypes.FindAsync(id);
    }

    public async Task UpdateAsync(StockType entity)
    {
        _context.StockTypes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.StockTypes.AnyAsync(x => x.Name == name);
    }
}

