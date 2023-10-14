using DotnetMarketplace.WebApps.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        public CategoryListViewComponent()
        {
                
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new List<HighlightCategory>(); 
            return View(model);
        }
    }
}
