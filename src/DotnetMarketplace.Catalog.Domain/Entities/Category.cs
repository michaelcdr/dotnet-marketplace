using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public string? Image { get; set; }
        public ICollection<SubCategory>? SubCategories { get; set; } = new HashSet<SubCategory>();
    }
}