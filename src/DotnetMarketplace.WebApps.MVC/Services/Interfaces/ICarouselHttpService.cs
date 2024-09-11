using DotnetMarketplace.WebApps.MVC.Models.Catalog;

namespace DotnetMarketplace.WebApps.MVC.Services.Interfaces;

public interface ICarouselHttpService
{
    Task<List<CarouselViewModel>> GetItems();
}