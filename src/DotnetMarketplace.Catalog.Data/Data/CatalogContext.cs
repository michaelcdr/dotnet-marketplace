using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Core.Data;
using DotnetMarketplace.Core.Messages;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Catalog.Data.Data
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsComments> ProductsComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var itens = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            foreach (var property in itens)
            {
                property.SetMaxLength(100);
                property.SetColumnType("varchar(100)");
            }

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
}