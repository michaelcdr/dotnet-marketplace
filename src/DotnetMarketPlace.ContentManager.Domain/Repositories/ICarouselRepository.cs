using MKT.ContentManager.Domain.Entities;

namespace MKT.ContentManager.Domain.Repositories
{
    public interface ICarouselRepository
    {
        Task<IEnumerable<CarouselImage>> ObterTodos();
    }
}
