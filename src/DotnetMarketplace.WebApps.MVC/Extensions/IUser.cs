using System.Security.Claims;

namespace DotnetMarketplace.WebApps.MVC.Extensions
{
    public interface IUser
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
