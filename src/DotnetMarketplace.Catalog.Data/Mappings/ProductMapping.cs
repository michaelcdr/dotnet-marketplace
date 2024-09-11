using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKT.Catalog.Domain.Entities;

namespace MKT.Catalog.Infra.Mappings
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

            builder.Property(e => e.Price).HasPrecision(18, 2).IsRequired();

            builder.Property(e => e.Stock).IsRequired();

            builder.Property(e => e.CreatedAt).IsRequired();

            builder.Property(e => e.CreatedBy).IsRequired();

            builder.Property(e => e.UserId).IsRequired();

            builder.HasMany(e => e.Comments).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);

            builder.HasMany(e => e.Images).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);

            builder.HasMany(e => e.AttributeValues).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
        }
    }

    public class ProductCommentMapping : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.ToTable("ProductsComments").HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.Description).HasMaxLength(5000).IsRequired();

            builder.Property(e => e.Ratting).IsRequired();
        }
    }

    public class ProductImageMapping : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductsImages").HasKey(e => e.Id);

            builder.Property(e => e.FileName).IsRequired();
        }
    }

    public class AttributeValueMapping : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            builder.ToTable("AttributesValues").HasKey(e => e.Id);

            builder.Property(e => e.Value).HasMaxLength(5000).IsRequired();
        }
    }

    public class AttributeMapping : IEntityTypeConfiguration<Domain.Entities.Attribute>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Attribute> builder)
        {
            builder.ToTable("Attributes").HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
        }
    }
}