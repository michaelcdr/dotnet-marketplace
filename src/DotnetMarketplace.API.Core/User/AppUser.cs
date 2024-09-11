using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MKT.API.Core.User
{
    public class AppUser : IAppUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Name => _httpContextAccessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaims()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _httpContextAccessor.HttpContext;
        }

        public string GetUserEmail()
        {
            return GetHttpContext().User.GetUserEmail();
        }

        public Guid GetUserId()
        {
            return new Guid(GetHttpContext().User.GetUserId());
        }

        public string GetUserToken()
        {
            return GetHttpContext().User.GetUserToken();
        }

        public bool HasRole(string role)
        {
            return GetHttpContext().User.IsInRole(role);
        }

        public bool IsAuthetiacated()
        {
            return GetHttpContext().User.Identity.IsAuthenticated;
        }
    }
}
