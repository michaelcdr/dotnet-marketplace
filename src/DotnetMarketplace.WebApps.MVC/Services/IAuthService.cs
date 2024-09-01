using DotnetMarketplace.Core.Responses;
using DotnetMarketplace.WebApps.MVC.Models;

namespace DotnetMarketplace.WebApps.MVC.Services;

/// <summary>
/// Service that comunicate with Autentication API.
/// </summary>
public interface IAuthService
{
    Task<TokenGeneratedResponse> Login(UserLogin loginModel);

    Task<TokenGeneratedResponse> Register(UserRegister loginModel);
}