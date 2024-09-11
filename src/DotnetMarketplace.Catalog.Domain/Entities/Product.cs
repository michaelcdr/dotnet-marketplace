using MKT.Core.DomainObjects;

namespace MKT.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; } = string.Empty;
        public bool OnSale { get; private set; }
        public int Stock { get; private set; }
        public string SKU { get; private set; } = string.Empty;
        public string UserId { get; private set; } = string.Empty;
        public Guid SubCategoryId { get; private set; }
        public SubCategory? SubCategory { get; private set; }
        public ICollection<AttributeValue> AttributeValues { get; private set; } = new HashSet<AttributeValue>();
        public ICollection<ProductComment> Comments { get; private set; } = new HashSet<ProductComment>();
        public ICollection<ProductImage> Images { get; private set; } = new HashSet<ProductImage>();

        protected Product() { }

        public Product(string title,
                       string? description,
                       decimal price,
                       string createdBy,
                       bool onSale,
                       int stock,
                       string sku,
                       string userId,
                       Guid subCategoryId)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
            Title = title;
            Description = description;
            Price = price;
            OnSale = onSale;
            Stock = stock;
            SKU = sku;
            UserId = userId;
            SubCategoryId = subCategoryId;

            Validate();
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Title)) throw new DomainException("Informe o titulo");

            if (string.IsNullOrEmpty(Description)) throw new DomainException("Informe o descritivo");

            if (Price <= 0) throw new DomainException("Preço deve ser maior que 0");

            if (string.IsNullOrEmpty(CreatedBy)) throw new DomainException("Informe o usuário");

            if (Stock < 0) throw new DomainException("Informe um estoque positivo");
        }
    }
}