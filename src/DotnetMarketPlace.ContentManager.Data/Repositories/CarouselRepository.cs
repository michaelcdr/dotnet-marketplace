using Microsoft.EntityFrameworkCore;
using MKT.ContentManager.Data.Data;
using MKT.ContentManager.Domain.Entities;
using MKT.ContentManager.Domain.Repositories;

namespace MKT.ContentManager.Data.Repositories
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
