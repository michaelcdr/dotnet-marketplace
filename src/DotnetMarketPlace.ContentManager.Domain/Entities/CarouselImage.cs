using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketPlace.ContentManager.Domain.Entities
{
    public class CarouselImage : Entity
    {
        public string FileName { get; private set; } = string.Empty;
        public int Ordem { get; private set; }
        public CarouselImage(string fileName, int ordem)
        {
            FileName = fileName;
            Ordem = ordem;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(FileName)) throw new DomainException("Informe o nome do Arquivo");

            if (Ordem > 0) throw new DomainException("A ordem deve ser maior que 0");
        }
    }
}