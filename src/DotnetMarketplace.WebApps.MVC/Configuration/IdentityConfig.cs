using Microsoft.AspNetCore.Authentication.Cookies;

namespace DotnetMarketplace.WebApps.MVC.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfigs(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "marketplace";
                    options.LoginPath = "/minha-conta/entrar";
                    options.AccessDeniedPath = "/acesso-negado";
                    //options.Events = new CookieAuthenticationEvents
                    //{
                    //    OnSignedIn = async context => { await Task.CompletedTask; },
                    //    OnSigningIn = async context => { await Task.CompletedTask; },
                    //    OnValidatePrincipal = async context => { await Task.CompletedTask; }
                    //};
                });
            return services;
        }

        public static IApplicationBuilder UseIdentityConfigs(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
