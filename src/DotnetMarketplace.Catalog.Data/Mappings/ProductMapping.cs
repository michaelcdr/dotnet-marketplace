using DotnetMarketplace.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetMarketplace.Catalog.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products")
                .HasKey(e => e.Id);

            builder.Property(e => e.SKU)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.Property(e => e.Stock).IsRequired();

            builder.Property(e => e.CreatedAt).IsRequired();

            builder.Property(e => e.CreatedBy).IsRequired();

            builder.Property(e => e.UserId).IsRequired();
        }
    }
}