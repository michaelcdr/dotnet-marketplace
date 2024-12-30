using MKT.Catalog.API.Models;
using MKT.Core.Communication;

namespace MKT.Catalog.API.Services;

public interface ICatalogService 
{
    Task<List<HighlightCategoryViewModel>> GetHighlightCategories();
    Task<List<CategoryItemMenu>> GetCategoriesNavMenu();
    Task<ProductsOnSaleViewModel> GetProductsOnSales();
    Task<AppResponse> SetProductsOnSale(Guid productId, string user);
}