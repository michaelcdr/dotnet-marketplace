using MKT.Core.DomainObjects;

namespace MKT.Catalog.Domain.Entities
{
    public class ProductImage : Entity
    {
        protected ProductImage() { }

        public Guid ProductId { get; private set; }
        public Product? Product { get; private set; } = null;
        public string FileName { get; set; } = string.Empty;
        public ProductImage(Guid id, Guid productId, string fileName)
        {
            Id = id;
            ProductId = productId;
            FileName = fileName;
        }
    }
}