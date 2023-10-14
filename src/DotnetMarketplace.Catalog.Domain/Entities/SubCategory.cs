using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class SubCategory: Entity
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }

        public SubCategory(string title, Category category)
        {
            Title = title;
            Category = category;
            CategoryId = category.Id;
        }
    }
}