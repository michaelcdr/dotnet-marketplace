using DotnetMarketplace.WebApps.MVC.Configuration;
using DotnetMarketplace.WebApps.MVC.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using MKT.Core.Communication;
using MKT.Core.Services;
using System.Security.Claims;

namespace DotnetMarketplace.WebApps.MVC.Services;

/// <summary>
/// Service that comunicate with Autentication API.
/// </summary>
public class AuthHttpService : ServiceBase, IAuthApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISerializerService _serializerService;

    public AuthHttpService(HttpClient httpClient,
                           IHttpContextAccessor httpContextAccessor,
                           ISerializerService serializerService,
                           IOptions<AppSettings> options) : base(serializerService)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _serializerService = serializerService;
        _httpClient.BaseAddress = new Uri(options.Value.UrlAuthApi);
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

        if (!HandleResponseErrors(response))
        {
            return new TokenGeneratedResponse
            {
                ResponseResult = await Deserialize<ResponseResult>(response)
            };
        }

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