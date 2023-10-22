using DotnetMarketplace.Catalog.Application.Services;
using DotnetMarketplace.Catalog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICatalogoService _catalogoService;

        public CategoryListViewComponent(ICatalogoService catalogoService)
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
