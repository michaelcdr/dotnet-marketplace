using DotnetMarketplace.WebApps.MVC.Configuration;
using DotnetMarketplace.WebApps.MVC.Models.Catalog;
using Microsoft.Extensions.Options;
using MKT.Core.Services;

namespace DotnetMarketplace.WebApps.MVC.Services;

public class CarouseApiService : ServiceBase, ICarouseApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISerializerService _serializerService;

    public CarouseApiService(HttpClient httpClient,
                               IHttpContextAccessor httpContextAccessor,
                               ISerializerService serializerService,
                               IOptions<AppSettings> options) : base(serializerService)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _serializerService = serializerService;
        _httpClient.BaseAddress = new Uri(options.Value.UrlContentManagerApi);
    }

    public async Task<List<CarouselViewModel>> GetItems()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/carousel");

        var carouselItems = await Deserialize<List<CarouselViewModel>>(response);
         
        return carouselItems;
    }
}