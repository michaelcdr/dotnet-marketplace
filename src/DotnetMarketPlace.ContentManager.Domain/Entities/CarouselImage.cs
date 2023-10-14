using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketPlace.ContentManager.Domain.Entities
{
    public class CarouselImage : Entity
    {
        public string FileName { get; private set; } = string.Empty;
        public int Ordem { get; private set; }
        public CarouselImage(string fileName, int ordem)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            Ordem = ordem;
        }
    }
}