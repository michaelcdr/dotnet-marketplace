using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class ProductComment : Entity
    {
        protected ProductComment() { }

        public ProductComment(Guid productId, 
                              string title, 
                              string description, 
                              bool recommend, 
                              string ratting)
        { 
            ProductId = productId;
            Title = title;
            Description = description;
            Recommend = recommend;
            Ratting = ratting;
        }

        public Guid ProductId { get; private set; }
        public Product? Product { get; private set; } 
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool Recommend { get; private set; }
        public string Ratting { get; private set; } = string.Empty;
    }
}