﻿using DotnetMarketplace.Catalog.Application.Services;
using DotnetMarketplace.Catalog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.ViewComponents
{
    public class NavViewComponent:ViewComponent
    {
        private readonly ICatalogoService _catalogoService;
        public NavViewComponent(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryItemMenu> categoryItemMenus = await _catalogoService.GetCategoriesNavMenu();
            
            var model = new NavViewModel 
            {
                Categories = categoryItemMenus,
            };

            return View(model);
        }
    }
}