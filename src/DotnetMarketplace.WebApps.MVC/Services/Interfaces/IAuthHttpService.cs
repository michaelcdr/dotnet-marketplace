using DotnetMarketplace.WebApps.MVC.Models.Auth;

namespace DotnetMarketplace.WebApps.MVC.Services.Interfaces;

/// <summary>
/// Service that comunicate with Autentication API.
/// </summary>
public interface IAuthHttpService
{
    Task<TokenGeneratedResponse> Login(UserLogin loginModel);

    Task<TokenGeneratedResponse> Register(UserRegister loginModel);
}