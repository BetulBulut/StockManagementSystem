using StockManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagementSystem.Infrastructure.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.ShelfInfo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CabinetInfo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CriticalQuantity)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasOne(x => x.StockType)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.StockTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.StockUnit)
            .WithMany()
            .HasForeignKey(x => x.StockUnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

