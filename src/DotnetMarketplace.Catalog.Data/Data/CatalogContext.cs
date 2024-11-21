using Microsoft.EntityFrameworkCore;
using MKT.Catalog.Domain.Entities;
using MKT.Core.Data;
using MKT.Core.Messages;

namespace MKT.Catalog.Infra.Data;

public class CatalogContext : DbContext, IUnitOfWork
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior  = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComment> ProductsComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

        //foreach (var entityType in entityTypes)
        //{
        //    var properties = entityType.GetProperties().Where(p => p.ClrType == typeof(string));

        //    foreach (var property in properties)
        //    {
        //        modelBuilder.Entity(entityType.Name).Property(property.Name).HasMaxLength(100).HasColumnType("varchar(100)");
        //    }
        //}
        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public async Task<bool> Commit()
    {
        var createdItens = ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null);

        foreach (var entry in createdItens)
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreateAt").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("CreateAt").IsModified = false;
        }

        var updatedItens = ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdatedAt") != null);

        foreach (var entryUpdated in updatedItens)
        {
            if (entryUpdated.State == EntityState.Added)
                entryUpdated.Property("UpdatedAt").IsModified = false;

            if (entryUpdated.State == EntityState.Modified)
                entryUpdated.Property("UpdatedAt").CurrentValue = DateTime.Now;
        }

        return await SaveChangesAsync() > 0;
    }
}