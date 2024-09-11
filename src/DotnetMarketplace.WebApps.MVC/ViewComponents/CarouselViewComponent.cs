using DotnetMarketplace.WebApps.MVC.Models.Catalog;
using DotnetMarketplace.WebApps.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents;

public class CarouselViewComponent : ViewComponent
{
    private readonly ICarouselHttpService _carouselService;

    public CarouselViewComponent(ICarouselHttpService carouselService)
    {
        _carouselService = carouselService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<CarouselViewModel> carouselItens = await _carouselService.GetItems();

        //var itens = new List<CarouselViewModel>();

        //foreach (var item in carouselItens)
        //    itens.Add(new CarouselItemViewModel { 
        //        File = $"/img/carousel/{item.FileName}" 
        //    });

        return View(carouselItens);
    }
}
