using MKT.Catalog.Domain.Entities;
using MKT.Core.Data;

namespace MKT.Catalog.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllOnSale();
    }
}
