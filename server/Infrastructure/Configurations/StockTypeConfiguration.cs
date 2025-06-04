using StockManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagementSystem.Infrastructure.Configurations;

public class StockTypeConfiguration : IEntityTypeConfiguration<StockType>
{
    public void Configure(EntityTypeBuilder<StockType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);
    }
}
