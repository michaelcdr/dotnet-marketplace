using DotnetMarketplace.WebApps.MVC.Models.Catalog;
using DotnetMarketplace.WebApps.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICatalogApiService _catalogoService;

        public CategoryListViewComponent(ICatalogApiService catalogoService)
        {
            _catalogoService = catalogoService; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<HighlightCategoryViewModel> model = await _catalogoService.GetHighlightCategories(); 

            return View(model);
        }
    }
}
