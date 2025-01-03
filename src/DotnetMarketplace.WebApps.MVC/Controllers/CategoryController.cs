﻿using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.Controllers
{
    public class CategoryController : MainController
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        } 
    }
}