using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Domain.Enums;

namespace StockManagementSystem.Infrastructure.Seed
{
    public static class StockUnitSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockUnit>().HasData(
                new
                {
                    Id = 1,
                    Code = "KGT",
                    StockTypeId = 1,
                    Unit = UnitEnum.Kilogram,
                    Description = "Kilogram birimi",
                    PurchasePrice = 10m,
                    PurchaseCurrency = CurrencyEnum.TRY,
                    SalePrice = 12m,
                    SaleCurrency = CurrencyEnum.TRY,
                    PaperWeight = "80gr",
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                },
                new
                {
                    Id = 2,
                    Code = "PCS",
                    StockTypeId = 1,
                    Unit = UnitEnum.Piece,
                    Description = "Adet birimi",
                    PurchasePrice = 1m,
                    PurchaseCurrency = CurrencyEnum.TRY,
                    SalePrice = 1.2m,
                    SaleCurrency = CurrencyEnum.TRY,
                    PaperWeight = (string?)null,
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                },
                new
                {
                    Id = 3,
                    Code = "LT",
                    StockTypeId = 2,
                    Unit = UnitEnum.Liter,
                    Description = "Litre birimi",
                    PurchasePrice = 5m,
                    PurchaseCurrency = CurrencyEnum.TRY,
                    SalePrice = 6m,
                    SaleCurrency = CurrencyEnum.TRY,
                    PaperWeight = (string?)null,
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}