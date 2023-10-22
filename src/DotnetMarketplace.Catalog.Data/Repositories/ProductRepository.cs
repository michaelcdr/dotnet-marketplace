using DotnetMarketplace.Catalog.Data.Data;
using DotnetMarketplace.Catalog.Domain.Repositories;
using DotnetMarketplace.Core.Data;

namespace DotnetMarketplace.Catalog.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _db;
        public IUnitOfWork UnitOfWork => _db;
        
        public ProductRepository(CatalogContext catalogContext)
        {
            _db = catalogContext;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
