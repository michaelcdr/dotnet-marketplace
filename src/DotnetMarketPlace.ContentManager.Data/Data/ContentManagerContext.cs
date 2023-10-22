using DotnetMarketplace.Core.Data;
using DotnetMarketplace.Core.Messages;
using DotnetMarketPlace.ContentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketPlace.ContentManager.Data.Data
{
    public class ContentManagerContext : DbContext, IUnitOfWork
    {
        public DbSet<CarouselImage> CarouselImages { get; set; }

        public ContentManagerContext(DbContextOptions<ContentManagerContext> options) 
            : base(options) 
        {
        
        }

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


           

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContentManagerContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}