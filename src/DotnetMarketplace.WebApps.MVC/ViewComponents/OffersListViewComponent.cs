using DotnetMarketplace.Catalog.Application.Services;
using DotnetMarketplace.Catalog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class OffersListViewComponent : ViewComponent
    {
        private readonly ICatalogService _catalogoService;

        public OffersListViewComponent(ICatalogService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ProductsOnSaleViewModel model = await _catalogoService.GetProductsOnSales();

            return View(model);
        }
    }
}
