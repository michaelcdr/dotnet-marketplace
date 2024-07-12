using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Auth.API.Services;
using DotnetMarketplace.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.Auth.API.Controllers;

[Route("api/conta")]
public class AuthController : MainController
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Gera um token para usar na autenticação da API
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("logar")]
    public async Task<IActionResult> Login(UserLogin model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var response = await _userService.Login(model);

        if (!response.Success) 
        {
            foreach (var item in response.Errors)
                AddError(item.Message);

            return CustomResponse();
        }

        return CustomResponse(response);
    }

    /// <summary>
    /// Registra um novo usuário
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("registrar")]
    public async Task<IActionResult> Register(UserRegister model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var response = await _userService.Register(model);

        if (!response.Success)
        {
            foreach (var item in response.Errors)
                AddError(item.Message);

            return CustomResponse();
        }

        return CustomResponse(response);
    }
}