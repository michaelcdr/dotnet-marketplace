﻿using DotnetMarketplace.WebApps.MVC.Configuration;
using DotnetMarketplace.WebApps.MVC.Models.Catalog;
using DotnetMarketplace.WebApps.MVC.Services.Interfaces;
using Microsoft.Extensions.Options;
using MKT.Core.Services;

namespace DotnetMarketplace.WebApps.MVC.Services;

public class CatalogHttpService : ServiceBase, ICatalogHttpService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISerializerService _serializerService;

    public CatalogHttpService(HttpClient httpClient,
                              IHttpContextAccessor httpContextAccessor,
                              ISerializerService serializerService,
                              IOptions<AppSettings> options) : base(serializerService)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _serializerService = serializerService;
        _httpClient.BaseAddress = new Uri(options.Value.UrlCatalogApi);
    }

    public async Task<List<HighlightCategoryViewModel>> GetHighlightCategories()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/catalog/category/highlight");

        var result = await Deserialize<List<HighlightCategoryViewModel>>(response);
        return result;
    }

    public async Task<List<CategoryItemMenu>> GetAll()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/catalog/category");

        var result = await Deserialize<List<CategoryItemMenu>>(response);
        return result;
    }

    public async Task<ProductsOnSaleViewModel> GetProductsOnSales()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/catalog/product/onsales");

        var result = await Deserialize<ProductsOnSaleViewModel>(response);
        return result;
    }
}