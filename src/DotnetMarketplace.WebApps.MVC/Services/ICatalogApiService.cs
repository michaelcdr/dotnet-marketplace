using DotnetMarketplace.WebApps.MVC.Models.Admin;
using DotnetMarketplace.WebApps.MVC.Models.Catalog;
using MKT.Core.Communication;

namespace DotnetMarketplace.WebApps.MVC.Services;

/// <summary>
/// Service that comunicate with Catalog API.
/// </summary>
public interface ICatalogApiService
{
    Task<List<HighlightCategoryViewModel>> GetHighlightCategories();
    Task<List<CategoryItemMenu>> GetAll();
    Task<ProductsOnSaleViewModel> GetProductsOnSales();
    Task<AppResponse> CreateProduct(CreateProductViewModel model);
}
