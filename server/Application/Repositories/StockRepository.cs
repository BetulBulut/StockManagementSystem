using StockManagementSystem.Application.Interfaces;
using StockManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.Application.Repositories;

public class StockRepository : IStockRepository
{
    private readonly AppDbContext _context;

    public StockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Stock entity)
    {
        await _context.Stocks.AddAsync(entity);
    }

    public async Task<List<Stock>> GetAllAsync()
    {
        return await _context.Stocks.Include(x => x.StockType).ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks.FindAsync(id);
    }

    public async Task UpdateAsync(Stock entity)
    {
        _context.Stocks.Update(entity);
    }
}

