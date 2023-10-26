using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class ProductImage : Entity
    {
        protected ProductImage() { }

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public string FileName { get; set; } = string.Empty;
    }
}