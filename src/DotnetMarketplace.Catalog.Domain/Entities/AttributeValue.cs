using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class AttributeValue : Entity
    {
        public Guid AttributeId { get; private set; }
        public Attribute? Attribute { get; private set; }
        public Guid ProductId { get; private set; }
        public Product? Product { get; private set; } 
        public string Value { get; private set; } = string.Empty;

        protected AttributeValue() { }
        public AttributeValue(Product product, Attribute attribute, string value)
        {
            AttributeId = attribute.Id;
            Attribute = attribute;
            ProductId = product.Id;
            Product = product;
            Value = value;
        }
    }
}