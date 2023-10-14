using DotnetMarketPlace.ContentManager.Data.Data;
using DotnetMarketPlace.ContentManager.Domain.Entities;
using DotnetMarketPlace.ContentManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketPlace.ContentManager.Data.Repositories
{
    public class CarouselRepository : ICarouselRepository
    {
        private readonly ContentManagerContext _context;

        public CarouselRepository(ContentManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarouselImage>> ObterTodos()
        {
            return await _context.CarouselImages.AsNoTracking()
                .OrderBy(e => e.Ordem).ToListAsync();
        }
    }
}
