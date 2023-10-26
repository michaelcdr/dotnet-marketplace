using DotnetMarketplace.Catalog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class OffersListViewComponent : ViewComponent
    {
        public OffersListViewComponent()
        {
                
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new HomeOffersViewModel();
            return View(model);
        }
    }
}
