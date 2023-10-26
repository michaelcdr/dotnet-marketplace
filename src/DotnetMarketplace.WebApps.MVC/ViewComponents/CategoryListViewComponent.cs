using DotnetMarketplace.Catalog.Application.Services;
using DotnetMarketplace.Catalog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICatalogService _catalogoService;

        public CategoryListViewComponent(ICatalogService catalogoService)
        {
            _catalogoService = catalogoService; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<HighlightCategoryViewModel> model = await _catalogoService.GetCategories(); 

            return View(model);
        }
    }
}
