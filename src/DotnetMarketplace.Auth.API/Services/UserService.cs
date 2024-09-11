using DotnetMarketplace.Auth.API.Jwt;
using DotnetMarketplace.Auth.API.Models;
using Microsoft.AspNetCore.Identity;
using MKT.Core.Responses;

namespace DotnetMarketplace.Auth.API.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ITokenGenerator _tokenGenerator;
    private const string MSG_ERRO = "Não foi possivel cadastrar o usuário.";
    private const string MSG_SUCESSO = "Usuário cadastrado com sucesso.";
    private const string MSG_ERRO_LOGAR = "Não foi possivel logar.";
    private const string MSG_ERRO_TOKEN = "Usuário registrado mas, não foi possivel gerar o token.";
    private const string ROLE_COMUM = "comum";
    private const string ROLE_VENDEDOR = "vendedor";
    private const string ROLE_ADMIN = "admin";

    public UserService(UserManager<IdentityUser> userManager,
                       SignInManager<IdentityUser> signInManager, 
                       ITokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AppResponse<TokenGeneratedResponse>> Register(UserRegister request)
    {
        var usuario = new IdentityUser 
        { 
            UserName = request.UserName,
            PasswordHash = request.Password
        };

        IdentityResult result = await _userManager.CreateAsync(usuario, request.Password);

        if (!result.Succeeded)
        {
            var notifications = new List<Notification>();

            foreach (var item in result.Errors)
                notifications.Add(new Notification(item.Description, string.Empty));
            
            return new AppResponse<TokenGeneratedResponse>(false, MSG_ERRO, notifications);
        }

        try
        {
            IdentityResult resultRole = await _userManager.AddToRoleAsync(usuario, ROLE_COMUM);

            if (!resultRole.Succeeded) 
            {
                var notifications = new List<Notification>();

                foreach (var item in result.Errors)
                    notifications.Add(new Notification(item.Description, string.Empty));

                await _userManager.DeleteAsync(usuario);
                return new AppResponse<TokenGeneratedResponse>(false, MSG_ERRO, notifications); 
            }
        }
        catch (Exception)
        {
            return new AppResponse<TokenGeneratedResponse>(false, MSG_ERRO);
        }
        
        TokenGeneratedResponse? tokenResultado = await _tokenGenerator.Generate(request.UserName);

        if (tokenResultado == null) return new AppResponse<TokenGeneratedResponse>(false, MSG_ERRO_TOKEN);

        return new AppResponse<TokenGeneratedResponse>(true, MSG_SUCESSO) 
        {
            Data = tokenResultado
        };
    }

    public async Task<AppResponse<TokenGeneratedResponse>> Login(UserLogin request)
    {
        var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);

        if (!result.Succeeded) 
            return new AppResponse<TokenGeneratedResponse>(false, MSG_ERRO_LOGAR, new List<Notification> { 
                new Notification(MSG_ERRO_LOGAR,"") 
            });

        TokenGeneratedResponse? tokenResultado = await _tokenGenerator.Generate(request.UserName);

        if (tokenResultado == null)
            return new AppResponse<TokenGeneratedResponse>(false, MSG_ERRO_LOGAR, new List<Notification> {
                new Notification(MSG_ERRO_LOGAR,"")
            });

        return new AppResponse<TokenGeneratedResponse>(true, "Logado com sucesso.") 
        {
            Data = tokenResultado
        };
    }
}