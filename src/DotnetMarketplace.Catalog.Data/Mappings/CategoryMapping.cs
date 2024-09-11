using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKT.Catalog.Domain.Entities;

namespace MKT.Catalog.Infra.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories")
                .HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.Image).IsRequired();
        }
    }
}
