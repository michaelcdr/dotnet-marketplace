using DotnetMarketplace.Core.Data;
using DotnetMarketplace.Core.Messages;
using DotnetMarketPlace.ContentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketPlace.ContentManager.Data.Data
{
    public class ContentManagerContext : DbContext, IUnitOfWork
    {
        public ContentManagerContext(DbContextOptions<ContentManagerContext> options) 
            : base(options) 
        {
        
        }
        
        public DbSet<CarouselImage> CarouselImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            foreach (var entityType in entityTypes)
            {
                var properties = entityType.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasMaxLength(100).HasColumnType("varchar(100)");
                }
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