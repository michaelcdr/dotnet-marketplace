using DotnetMarketplace.Catalog.Application.ViewModels;

namespace DotnetMarketplace.Catalog.Application.Services
{
    public interface ICatalogService : IDisposable
    {
        Task<List<HighlightCategoryViewModel>> GetCategories();
        Task<List<CategoryItemMenu>> GetCategoriesNavMenu();
        Task<ProductsOnSaleViewModel> GetProductsOnSales();
    }
}
