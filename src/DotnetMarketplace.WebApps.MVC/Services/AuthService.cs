using DotnetMarketplace.Core.Communication;
using DotnetMarketplace.Core.Services;
using DotnetMarketplace.WebApps.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace DotnetMarketplace.WebApps.MVC.Services;

public class AuthService : ServiceBase, IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(HttpClient httpClient,
                       IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _httpClient.BaseAddress = new Uri("https://localhost:7070/");
    }

    public async Task<TokenGeneratedResponse> Login(UserLogin loginModel)
    {
        HttpResponseMessage response = await _httpClient.PostAsync("api/conta/login", FormatContent(loginModel));

        if (!HandleResponseErrors(response)) 
            return new TokenGeneratedResponse
            {
                ResponseResult = await Deserialize<ResponseResult>(response)
            };

        var result = await Deserialize<TokenGeneratedResponse>(response);

        if (result == null) throw new InvalidOperationException("Resultado inválido ao tentar logar.");

        await AutenticarRegistrandoClaims(result);

        return result;
    }

    public async Task<TokenGeneratedResponse> Register(UserRegister loginModel)
    {
        var response = await _httpClient.PostAsync("api/conta/registro", FormatContent(loginModel));

        string retorno = await response.Content.ReadAsStringAsync();
        
        if (!HandleResponseErrors(response)) return await Deserialize<TokenGeneratedResponse>(response);

        var result = await Deserialize<TokenGeneratedResponse>(response);

        if (result == null) throw new InvalidOperationException("Resultado inválido ao tentar registrar usuário.");

        await AutenticarRegistrandoClaims(result);

        return result;
    } 

    private async Task AutenticarRegistrandoClaims(TokenGeneratedResponse tokenResult)
    {
        var claims = new List<Claim>
        {
            new Claim("JWT", tokenResult.AccessToken)
        };
        claims.AddRange(tokenResult.UserToken.Claims.Select(e => new Claim(e.Type, e.Value)).ToList());

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var authProp = new AuthenticationProperties
        {
            IssuedUtc = DateTime.UtcNow,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
            IsPersistent = true
        };
        
        await _httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            claimsPrincipal, 
            authProp
        );
    }
}