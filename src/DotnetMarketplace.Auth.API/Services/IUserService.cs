using DotnetMarketplace.Auth.API.Jwt;
using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Core.Responses;

namespace DotnetMarketplace.Auth.API.Services
{
    public interface IUserService
    {
        Task<AppResponse<TokenGeneratedResponse>> Login(UserLogin request);
        Task<AppResponse<TokenGeneratedResponse>> Register(UserRegister request);
    }
}