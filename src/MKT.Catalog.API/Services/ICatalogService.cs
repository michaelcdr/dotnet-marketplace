using MKT.Catalog.API.Models;

namespace MKT.Catalog.API.Services;

public interface ICatalogService 
{
    Task<List<HighlightCategoryViewModel>> GetHighlightCategories();
    Task<List<CategoryItemMenu>> GetCategoriesNavMenu();
    Task<ProductsOnSaleViewModel> GetProductsOnSales();
}