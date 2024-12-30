using DotnetMarketplace.WebApps.MVC.Models.Admin;
using DotnetMarketplace.WebApps.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKT.Core.Communication;

namespace DotnetMarketplace.WebApps.MVC.Controllers;

[Authorize]
public class ProductController : MainController
{
    private readonly ILogger<ProductController> _logger;
    private readonly ICatalogApiService _api;

    public ProductController(ILogger<ProductController> logger,
                             ICatalogApiService catalogService)
    {
        _logger = logger;
        _api = catalogService;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel model)
    {
        AppResponse response = await _api.CreateProduct(model);

        return View(model);
    }
}