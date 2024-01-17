using DotnetMarketplace.Catalog.Data.Data;
using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Catalog.Domain.Repositories;
using DotnetMarketplace.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Catalog.Data.Repositories
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
            return await _db.Categories.AsNoTracking().OrderBy(e => e.Title).ToListAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}