using DotnetMarketplace.WebApps.MVC.Models.Catalog;
using DotnetMarketplace.WebApps.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICatalogHttpService _catalogoService;

        public CategoryListViewComponent(ICatalogHttpService catalogoService)
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
