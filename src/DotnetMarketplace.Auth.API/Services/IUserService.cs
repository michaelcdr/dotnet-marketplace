using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Core.Responses;

namespace DotnetMarketplace.Auth.API.Services
{
    public interface IUserService
    {
        Task<AppResponse<object>> Login(UserLogin request);
        Task<AppResponse<object>> Register(UserRegister request);
    }
}