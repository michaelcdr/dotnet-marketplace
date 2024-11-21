using Microsoft.EntityFrameworkCore;
using MKT.Catalog.Infra.Data;
using MKT.Catalog.Domain.Entities;
using MKT.Catalog.Domain.Repositories;
using MKT.Core.Data;

namespace MKT.Catalog.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly CatalogContext _db;
        public IUnitOfWork UnitOfWork => _db;

        public CategoryRepository(CatalogContext catalogContext)
        {
            _db = catalogContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _db.Categories.Include(s => s.SubCategories)
                .AsNoTracking().OrderBy(e => e.Title)
                .ToListAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}