using DotnetMarketplace.WebApps.MVC.Models.Auth;

namespace DotnetMarketplace.WebApps.MVC.Services;

/// <summary>
/// Service that comunicate with Autentication API.
/// </summary>
public interface IAuthApiService
{
    Task<TokenGeneratedResponse> Login(UserLogin loginModel);

    Task<TokenGeneratedResponse> Register(UserRegister loginModel);
}