using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class ProductsComments:Entity
    {
        protected ProductsComments() { }
        public ProductsComments(Guid productId, Product product, string title, string description, bool recommend, string ratting)
        {
            ProductId = productId;
            Product = product;
            Title = title;
            Description = description;
            Recommend = recommend;
            Ratting = ratting;
        }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Recommend { get; set; }
        public string Ratting { get; set; } = string.Empty;
    }
}