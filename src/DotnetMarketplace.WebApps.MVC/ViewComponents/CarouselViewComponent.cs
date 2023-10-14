using DotnetMarketplace.WebApps.MVC.Models;
using DotnetMarketPlace.ContentManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {
        private readonly ICarouselRepository _carouselRepository;

        public CarouselViewComponent(ICarouselRepository carouselRepository)
        {
            _carouselRepository = carouselRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carouselItens = await _carouselRepository.ObterTodos();

            var itens = new List<CarouselItemViewModel>();

            foreach (var item in carouselItens)
                itens.Add(new CarouselItemViewModel { File = $"/img/carousel/{item.FileName}" });

            return View(itens);
        }
    }
}
