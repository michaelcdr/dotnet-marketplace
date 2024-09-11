using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKT.Catalog.Domain.Entities;

namespace MKT.Catalog.Infra.Mappings
{
    public class SubCategoryMapping : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategories")
                .HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired();

            builder.Property(e => e.CategoryId).IsRequired();
        }
    }
}
