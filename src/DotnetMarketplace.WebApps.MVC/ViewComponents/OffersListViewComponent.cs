using DotnetMarketplace.WebApps.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents;

public class OffersListViewComponent : ViewComponent
{
    private readonly ICatalogApiService _catalogoService;

    public OffersListViewComponent(ICatalogApiService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ProductsOnSaleViewModel model = await _catalogoService.GetProductsOnSales();

        return View(model);
    }
}