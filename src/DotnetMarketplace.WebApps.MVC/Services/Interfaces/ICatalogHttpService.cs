using DotnetMarketplace.WebApps.MVC.Models.Catalog;

namespace DotnetMarketplace.WebApps.MVC.Services.Interfaces;

/// <summary>
/// Service that comunicate with Catalog API.
/// </summary>
public interface ICatalogHttpService
{
    Task<List<HighlightCategoryViewModel>> GetHighlightCategories();
    Task<List<CategoryItemMenu>> GetAll();
    Task<ProductsOnSaleViewModel> GetProductsOnSales();
}
