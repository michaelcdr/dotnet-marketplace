using DotnetMarketplace.WebApps.MVC.Services;
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

        services.AddHttpClient<IAuthApiService, AuthHttpService>();
        services.AddHttpClient<ICatalogApiService, CatalogApiService>();
        services.AddHttpClient<ICarouseApiService, CarouseApiService>();

        services.AddScoped<IAppUser, AppUser>();
        services.AddScoped<IMediatrHandler, MediatrHandler>();
        services.AddScoped<ISerializerService ,SerializerService>();
        return services;
    }
}