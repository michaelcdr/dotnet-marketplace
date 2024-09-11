using MKT.Catalog.Domain.Entities;
using MKT.Core.Data;

namespace MKT.Catalog.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategories();
    }
}
