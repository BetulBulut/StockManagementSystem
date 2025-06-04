using StockManagementSystem.Application.Interfaces;
using StockManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.Application.Repositories;

public class StockUnitRepository : IStockUnitRepository
{
    private readonly AppDbContext _context;

    public StockUnitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StockUnit entity)
    {
        await _context.StockUnits.AddAsync(entity);
    }

    public async Task<List<StockUnit>> GetAllAsync()
    {
        return await _context.StockUnits.Include(x => x.StockType).ToListAsync();
    }

    public async Task<StockUnit?> GetByIdAsync(int id)
    {
        return await _context.StockUnits.FindAsync(id);
    }

    public async Task UpdateAsync(StockUnit entity)
    {
        _context.StockUnits.Update(entity);
    }

    public async Task<bool> ExistsByCodeAsync(string code)
    {
        return await _context.StockUnits.AnyAsync(x => x.Code == code);
    }
}

