using Microsoft.EntityFrameworkCore;
using MKT.Catalog.Domain.Entities;
using MKT.Catalog.Domain.Repositories;
using MKT.Catalog.Infra.Data;
using MKT.Core.Data;

namespace MKT.Catalog.Infra.Repositories;

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

    public async Task<List<Product>> GetAllOnSale()
    {
        return await _db.Products.Where(e => e.OnSale).AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _db.Products.Where(e => e.Id == id).SingleAsync();
    }
}
