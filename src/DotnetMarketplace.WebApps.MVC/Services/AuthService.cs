using DotnetMarketplace.Core.Responses;
using DotnetMarketplace.WebApps.MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace DotnetMarketplace.WebApps.MVC.Services;

public class AuthService : IAuthService
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

    public async Task<AppResponse<TokenGeneratedResponse>> Login(UserLogin loginModel)
    {
        var opts = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        var content = new StringContent(
            JsonSerializer.Serialize(loginModel, opts),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("api/conta/login", content);

        string retorno = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<AppResponse<TokenGeneratedResponse>>(retorno, opts);

        if (result == null || result.Data == null) return new AppResponse<TokenGeneratedResponse>(false, "erro");

        await AutenticarRegistrandoClaimns(result.Data);

        return result;
    }

    public async Task<AppResponse<TokenGeneratedResponse>> Register(UserRegister loginModel)
    {
        var opts = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var content = new StringContent(
            JsonSerializer.Serialize(loginModel, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("api/conta/registro", content);

        string retorno = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<AppResponse<TokenGeneratedResponse>>(retorno, opts);

        if (result == null || result.Data == null) return new AppResponse<TokenGeneratedResponse>(false, "erro");

        await AutenticarRegistrandoClaimns(result.Data);

        return result;
    } 

    private async Task AutenticarRegistrandoClaimns(TokenGeneratedResponse tokenResult)
    {
        var claims = new List<Claim>();

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