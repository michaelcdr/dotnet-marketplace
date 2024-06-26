using Microsoft.AspNetCore.Identity;

namespace DotnetMarketplace.Auth.API.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}