﻿using DotnetMarketplace.Catalog.Application.Services;
using DotnetMarketplace.Catalog.Data.Repositories;
using DotnetMarketplace.Catalog.Domain.Repositories;
using DotnetMarketplace.Core.Bus;
using DotnetMarketPlace.ContentManager.Data.Repositories;
using DotnetMarketPlace.ContentManager.Domain.Repositories;

namespace DotnetMarketplace.WebApps.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

        services.AddScoped<IMediatrHandler, MediatrHandler>();
        services.AddScoped<ICarouselRepository, CarouselRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICatalogService, CatalogService>();

        return services;
    }
}