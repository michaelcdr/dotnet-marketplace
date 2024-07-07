namespace DotnetMarketplace.Auth.API.Jwt
{
    public interface ITokenGenerator
    {
        Task<TokenGeneratedResponse?> Generate(string userName);
    }
}
