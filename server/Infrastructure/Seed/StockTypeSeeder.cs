using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Domain.Entities;

namespace StockManagementSystem.Infrastructure.Seed
{
    public static class StockTypeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockType>().HasData(
                new
                {
                    Id = 1,
                    Name = "Kağıt",
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                },
                new
                {
                    Id = 2,
                    Name = "Kimyasal",
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                },
                new
                {
                    Id = 3,
                    Name = "Makine Parçası",
                    IsActive = true,
                    InsertedDate = new DateTime(2024, 1, 1),
                    UpdatedDate = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}