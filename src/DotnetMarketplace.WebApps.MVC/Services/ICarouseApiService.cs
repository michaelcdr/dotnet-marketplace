using DotnetMarketplace.WebApps.MVC.Models.Catalog;

namespace DotnetMarketplace.WebApps.MVC.Services;

public interface ICarouseApiService
{
    Task<List<CarouselViewModel>> GetItems();
}