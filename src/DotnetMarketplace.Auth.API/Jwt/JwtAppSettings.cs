namespace DotnetMarketplace.Auth.API.Jwt
{
    public class JwtAppSettings
    {
        public string Secret { get; set; } = string.Empty;
        public double ExpiresIn { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
