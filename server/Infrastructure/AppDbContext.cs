using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Infrastructure.Configurations;
using StockManagementSystem.Infrastructure.Seed;

namespace StockManagementSystem.Infrastructure
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockConfiguration).Assembly);
            StockTypeSeeder.Seed(modelBuilder);
            StockUnitSeeder.Seed(modelBuilder);
            StockSeeder.Seed(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entyList = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity
         && (e.State == EntityState.Deleted || e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entyList)
        {
            var baseEntity = (BaseEntity)entry.Entity;
            if (entry.State == EntityState.Added)
            {
                baseEntity.InsertedDate = DateTime.Now;
                baseEntity.IsActive = true;
                baseEntity.UpdatedDate = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdatedDate = DateTime.Now;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.IsActive = false;
                baseEntity.UpdatedDate = DateTime.Now;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
    }
}
