using StockManagementSystem.Application.Interfaces;
using StockManagementSystem.Application.Repositories;
using Serilog;
using StockManagementSystem.Infrastructure;

namespace StockManagementSystem.Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IStockTypeRepository StockTypes => new StockTypeRepository(_context);
    public IStockUnitRepository StockUnits => new StockUnitRepository(_context);
    public IStockRepository Stocks => new StockRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task Complete()
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while saving changes to the database.");
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private bool _disposed = false;
    
}

