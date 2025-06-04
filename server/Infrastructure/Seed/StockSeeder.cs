using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Domain.Enums;

namespace StockManagementSystem.Infrastructure.Seed
{
    public static class StockSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 1,
                    Class = StockClassEnum.RawMaterial,
                    StockTypeId = 1,
                    StockUnitId = 1,
                    Quantity = 100,
                    ShelfInfo = "A1",
                    CabinetInfo = "K1",
                    CriticalQuantity = 10,
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                },
                new Stock
                {
                    Id = 2,
                    Class = StockClassEnum.FinishedProduct,
                    StockTypeId = 2,
                    StockUnitId = 2,
                    Quantity = 50,
                    ShelfInfo = "B2",
                    CabinetInfo = "K2",
                    CriticalQuantity = 5,
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}