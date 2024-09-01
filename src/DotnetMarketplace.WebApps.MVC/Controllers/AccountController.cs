using DotnetMarketplace.WebApps.MVC.Models;
using DotnetMarketplace.WebApps.MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotnetMarketplace.WebApps.MVC.Controllers;

public class AccountController : MainController
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAuthService _authService;

    public AccountController(ILogger<AccountController> logger,
                             IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("/minha-conta/entrar")]
    public IActionResult Login()
    {
        return View();
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}