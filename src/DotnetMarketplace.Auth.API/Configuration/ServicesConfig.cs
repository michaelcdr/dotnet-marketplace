using DotnetMarketplace.Auth.API.Jwt;
using DotnetMarketplace.Auth.API.Services;

namespace DotnetMarketplace.Auth.API.Configuration
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            return services;
        }
    }
}
