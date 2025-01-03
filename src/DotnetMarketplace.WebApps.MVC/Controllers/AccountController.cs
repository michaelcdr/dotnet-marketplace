﻿using DotnetMarketplace.WebApps.MVC.Models;
using DotnetMarketplace.WebApps.MVC.Models.Auth;
using DotnetMarketplace.WebApps.MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotnetMarketplace.WebApps.MVC.Controllers;

public class AccountController : MainController
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAuthApiService _authService;

    public AccountController(ILogger<AccountController> logger,
                             IAuthApiService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public IActionResult Index() => View();

    [Route("/minha-conta/entrar")]
    public IActionResult Login()
    {
        if (User.Identity == null || !User.Identity.IsAuthenticated) return View();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Route("/minha-conta/entrar")]
    public async Task<IActionResult> Login(UserLogin model)
    {
        if (!ModelState.IsValid) return View(model);

        var response = await _authService.Login(model);

        if (ResponsePossuiErros(response.ResponseResult)) return View(model);
        
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Route("/minha-conta/sair")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("/minha-conta/registrar")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("/minha-conta/registrar")]
    public async Task<ActionResult> Register(UserRegister model)
    {
        if (!ModelState.IsValid) return View(model);

        var response = await _authService.Register(model);

        if (ResponsePossuiErros(response.ResponseResult)) return View(model);

        return RedirectToAction("Index", "Home");
    }
}