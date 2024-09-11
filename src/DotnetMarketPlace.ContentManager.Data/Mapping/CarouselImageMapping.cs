using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MKT.ContentManager.Domain.Entities;

namespace MKT.ContentManager.Data.Mapping
{
    public class CarouselImageMapping : IEntityTypeConfiguration<CarouselImage>
    {
        public void Configure(EntityTypeBuilder<CarouselImage> builder)
        {
            builder
               .ToTable("CarouselImages")
               .HasKey(e => e.Id);

            builder
                .Property(e => e.FileName)
                .IsRequired();

            builder
                .Property(e => e.Ordem)
                .IsRequired();
        }
    }
}
