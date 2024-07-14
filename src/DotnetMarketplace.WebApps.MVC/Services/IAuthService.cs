using DotnetMarketplace.Core.Responses;
using DotnetMarketplace.WebApps.MVC.Models;

namespace DotnetMarketplace.WebApps.MVC.Services
{
    public interface IAuthService
    {
        Task<AppResponse<TokenGeneratedResponse>> Login(UserLogin loginModel);

        Task<AppResponse<TokenGeneratedResponse>> Register(UserRegister loginModel);
    }
}