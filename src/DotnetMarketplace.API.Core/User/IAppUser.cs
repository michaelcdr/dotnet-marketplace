using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MKT.API.Core.User
{
    public interface IAppUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool IsAuthetiacated();
        bool HasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();
    }
}
