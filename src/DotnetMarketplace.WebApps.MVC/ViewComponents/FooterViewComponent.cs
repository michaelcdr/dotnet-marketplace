using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
