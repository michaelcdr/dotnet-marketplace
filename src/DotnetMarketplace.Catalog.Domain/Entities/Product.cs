using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public int Title { get; private set; }
        public string? Description { get; private set; }
        public decimal? Price { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public bool Offer { get; private set; }
        public bool Stock { get; private set; }
        public string SKU { get; private set; } = string.Empty;
        public string UserId { get; private set; } = string.Empty;
        public Guid SubCategoryId { get; private set; } 
        public SubCategory? SubCategory { get; private set; }    
        public ICollection<AttributeValue> AttributeValues { get; private set; } = new HashSet<AttributeValue>();
    }

    public class SimilarProduct
    {

    }
}