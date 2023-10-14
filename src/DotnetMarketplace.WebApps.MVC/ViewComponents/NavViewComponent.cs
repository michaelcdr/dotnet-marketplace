using DotnetMarketplace.WebApps.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class NavViewComponent:ViewComponent
    {
        public NavViewComponent()
        {
                
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new NavViewModel();
            return View(model);
        }
    }
}
