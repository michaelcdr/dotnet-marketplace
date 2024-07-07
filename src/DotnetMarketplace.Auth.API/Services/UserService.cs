using DotnetMarketplace.Auth.API.Jwt;
using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Core.Responses;
using Microsoft.AspNetCore.Identity;

namespace DotnetMarketplace.Auth.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;
        private const string MSG_ERRO = "Não foi possivel cadastrar o usuário.";
        private const string MSG_SUCESSO = "Usuário cadastrado com sucesso.";
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

        public async Task<AppResponse<object>> Register(UserRegister request)
        {
            var usuario = new IdentityUser 
            { 
                UserName = request.UserName,
                PasswordHash = request.Password
            };

            IdentityResult result = await _userManager.CreateAsync(usuario, request.Password);

            if (!result.Succeeded) return new AppResponse<object>(false, MSG_ERRO);

            try
            {
                IdentityResult resultRole = await _userManager.AddToRoleAsync(usuario, ROLE_COMUM);

                if (!resultRole.Succeeded) 
                { 
                    await _userManager.DeleteAsync(usuario);
                    return new AppResponse<object>(false, MSG_ERRO); 
                }
            }
            catch (Exception)
            {
                return new AppResponse<object>(false, MSG_ERRO);
            }
            
            TokenGeneratedResponse? tokenResultado = await _tokenGenerator.Generate(request.UserName);

            if (tokenResultado == null) new AppResponse<object>(false, "Usuário registrado mas, não foi possivel gerar o token.");

            return new AppResponse<object>(true, MSG_SUCESSO) 
            {
                Data = tokenResultado
            };
        }

        public async Task<AppResponse<object>> Login(UserLogin request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);

            if (!result.Succeeded) new AppResponse<object>(false, "Não foi possivel logar.");

            TokenGeneratedResponse? tokenResultado = await _tokenGenerator.Generate(request.UserName);

            if (tokenResultado == null) new AppResponse<object>(false, "Não foi possivel logar.");

            return new AppResponse<object>(true, "Logado com sucesso.") 
            {
                Data = tokenResultado
            };
        }
    }
}