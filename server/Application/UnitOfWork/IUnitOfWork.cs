using System.Threading.Tasks;
using StockManagementSystem.Application.Interfaces;

namespace StockManagementSystem.Application.UnitOfWork;

public interface IUnitOfWork
{
    IStockTypeRepository StockTypes { get; }
    IStockUnitRepository StockUnits { get; }
    IStockRepository Stocks { get; }

    Task<int> SaveChangesAsync();
    Task Complete();
    }

