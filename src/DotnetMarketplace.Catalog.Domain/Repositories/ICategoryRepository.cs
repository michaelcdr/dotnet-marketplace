using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Core.Data;

namespace DotnetMarketplace.Catalog.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategories();
    }
}
