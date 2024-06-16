using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class SubCategory : Entity
    {
        public Guid CategoryId { get; private set; } = Guid.Empty;
        public Category? Category { get; set; }
        public string Title { get; private set; } = string.Empty;

        protected SubCategory() { }

        public SubCategory(string title, Category category)
        {
            Title = title;
            Category = category;
            CategoryId = category.Id;
           
            Validate();
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Title)) throw new DomainException("Informe o titulo");

            if (CategoryId == Guid.Empty) throw new DomainException("Informe uma categoria");
        }
    }
}