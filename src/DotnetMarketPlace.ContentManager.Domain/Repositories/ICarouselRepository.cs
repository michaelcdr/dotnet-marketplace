using DotnetMarketPlace.ContentManager.Domain.Entities;

namespace DotnetMarketPlace.ContentManager.Domain.Repositories
{
    public interface ICarouselRepository
    {
        Task<IEnumerable<CarouselImage>> ObterTodos();
    }
}
