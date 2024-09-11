using DotnetMarketplace.WebApps.MVC.Services;
using DotnetMarketplace.WebApps.MVC.Services.Interfaces;
using MKT.API.Core.User;
using MKT.Core.Bus;
using MKT.Core.Services;

namespace DotnetMarketplace.WebApps.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

        services.AddHttpClient<IAuthHttpService, AuthHttpService>();
        services.AddHttpClient<ICatalogHttpService, CatalogHttpService>();
        services.AddHttpClient<ICarouselHttpService, CarouselHttpService>();

        services.AddScoped<IAppUser, AppUser>();
        services.AddScoped<IMediatrHandler, MediatrHandler>();
        services.AddScoped<ISerializerService ,SerializerService>();
        return services;
    }
}