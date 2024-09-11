﻿using DotnetMarketplace.WebApps.MVC.Models;
using DotnetMarketplace.WebApps.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents;

public class NavViewComponent : ViewComponent
{
    private readonly ICatalogHttpService _catalogoHttpService;

    public NavViewComponent(ICatalogHttpService catalogoService)
    {
        _catalogoHttpService = catalogoService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<CategoryItemMenu> categoryItemMenus = await _catalogoHttpService.GetAll();
        
        var model = new NavViewModel 
        {
            Categories = categoryItemMenus,
        };

        return View(model);
    }
}