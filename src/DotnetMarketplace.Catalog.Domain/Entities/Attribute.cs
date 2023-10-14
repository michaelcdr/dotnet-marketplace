using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class Attribute : Entity, IAggregateRoot
    {
        public Attribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
    }
}