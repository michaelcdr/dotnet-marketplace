using DotnetMarketplace.Auth.API.Models;

namespace DotnetMarketplace.Auth.API.Jwt
{
    public class TokenGeneratedResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public double ExpiresIn { get; set; }
        public UserToken? UserToken { get;  set; }
    }
}
