using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Core.Responses;
using Microsoft.AspNetCore.Identity;

namespace DotnetMarketplace.Auth.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private const string MSG_ERRO = "Não foi possivel cadastrar o usuário.";
        private const string MSG_SUCESSO = "Usuário cadastrado com sucesso.";
        private const string ROLE_COMUM = "comum";

        public UserService(UserManager<User> userManager,
                           SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppResponse<object>> Register(UserRegister request)
        {
            var usuario = new User 
            { 
                UserName = request.UserName,
                PasswordHash = request.Password
            };

            //if (!usuario.TaValido()) return new AppResponse<object>(false, "Dados inválidos", usuario.ObterErros());

            IdentityResult result = await _userManager.CreateAsync(usuario, request.Password);

            if (!result.Succeeded) return new AppResponse<object>(false, MSG_ERRO);
            
            IdentityResult resultRole = await _userManager.AddToRoleAsync(usuario, ROLE_COMUM);

            if (!resultRole.Succeeded) return new AppResponse<object>(false, MSG_ERRO);
            
            return new AppResponse<object>(true, MSG_SUCESSO);
        }

        public async Task<AppResponse<object>> Login(UserLogin request)
        {
            //AppResponse<TokenResultado> tokenResultado = await _geradorToken.Gerar(request.Usuario);

            //if (!tokenResultado.Sucesso) return new AppResponse<object>(tokenResultado.Mensagem, false, tokenResultado.Erros);

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);

            if (!result.Succeeded) new AppResponse<object>(false, "Não foi possivel logar.");

            return new AppResponse<object>(true, "Logado com sucesso.");
        }
    }

    public interface IUserService
    {
        Task<AppResponse<object>> Login(UserLogin request);
        Task<AppResponse<object>> Register(UserRegister request);
    }

}
