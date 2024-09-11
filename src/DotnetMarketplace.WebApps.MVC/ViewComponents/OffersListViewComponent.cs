using DotnetMarketplace.WebApps.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents;

public class OffersListViewComponent : ViewComponent
{
    private readonly ICatalogHttpService _catalogoService;

    public OffersListViewComponent(ICatalogHttpService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ProductsOnSaleViewModel model = await _catalogoService.GetProductsOnSales();

        return View(model);
    }
}