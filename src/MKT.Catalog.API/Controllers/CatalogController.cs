using Microsoft.AspNetCore.Mvc;
using MKT.API.Core.Controllers;
using MKT.Catalog.API.Models;
using MKT.Catalog.API.Services;
using MKT.Core.Communication;

namespace MKT.Auth.API.Controllers;

[Route("api/catalog")]
public class CatalogController : MainApiController
{
    private readonly ICatalogService _catalogoService;

    public CatalogController(ICatalogService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    [HttpGet, Route("category/highlight")]
    public async Task<IActionResult> GetHighlightCategories()
    {
        List<HighlightCategoryViewModel> categories = await _catalogoService.GetHighlightCategories();
        return CustomResponse(categories);
    }

    [HttpGet, Route("category")]
    public async Task<IActionResult> GetAllCategories()
    {
        List<CategoryItemMenu> categories = await _catalogoService.GetCategoriesNavMenu();
        return CustomResponse(categories);
    }

    [HttpGet, Route("product/onsales")]
    public async Task<IActionResult> GetProductsOnSales()
    {
        ProductsOnSaleViewModel categories = await _catalogoService.GetProductsOnSales();
        return CustomResponse(categories);
    }

    [HttpPost, Route("product/onsale/{id}")]
    public async Task<IActionResult> SetProductsOnSale(Guid id)
    {
        AppResponse result = await _catalogoService.SetProductsOnSale(id, "usuario-teste");
        return CustomResponse(result);
    }
}