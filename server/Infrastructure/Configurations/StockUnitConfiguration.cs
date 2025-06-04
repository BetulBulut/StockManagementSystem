using StockManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StockUnitConfiguration : IEntityTypeConfiguration<StockUnit>
{
    public void Configure(EntityTypeBuilder<StockUnit> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);
    }
}

