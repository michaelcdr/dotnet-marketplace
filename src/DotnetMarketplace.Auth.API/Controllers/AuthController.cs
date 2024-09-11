using DotnetMarketplace.Auth.API.Jwt;
using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Auth.API.Services;
using Microsoft.AspNetCore.Mvc;
using MKT.API.Core.Controllers;
using MKT.Core.Responses;

namespace DotnetMarketplace.Auth.API.Controllers;

[Route("api/conta")]
public class AuthController : MainApiController
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
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        AppResponse<TokenGeneratedResponse> response = await _userService.Login(model);

        if (!response.Success) 
        {
            foreach (var item in response.Errors)
                AddError(item.Message);

            return CustomResponse();
        }

        return CustomResponse(response.Data);
    }

    /// <summary>
    /// Registra um novo usuário
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("registro")]
    public async Task<IActionResult> Register(UserRegister model)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        AppResponse<TokenGeneratedResponse> response = await _userService.Register(model);

        if (!response.Success)
        {
            foreach (Notification notification in response.Errors)
                AddError(notification.Message);

            return CustomResponse();
        }

        return CustomResponse(response.Data);
    }
}