using DotnetMarketplace.Auth.API.Data;
using DotnetMarketplace.Auth.API.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DotnetMarketplace.Auth.API.Configuration;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<IdentityUser, IdentityRole>()
            //.AddRoles<IdentityRole>()
            //.AddErrorDescriber<IdentityErrosEmPortugues>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        AddJWTConfiguration(services, configuration);

        // definições de regras de segurança para a password
        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequiredLength = 3;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequiredUniqueChars = 0;
            opt.User.RequireUniqueEmail = false;
        });
        return services;
    }

    public static IApplicationBuilder UseIdentity(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        SeedIdentityConfigs(app);

        return app;
    }

    private static void SeedIdentityConfigs(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!db.Roles.Any(r => r.Name == "admin"))
            {
                db.Roles.Add(new IdentityRole("admin"));
                db.SaveChanges();
            }

            if (!db.Roles.Any(r => r.Name == "comum"))
            {
                db.Roles.Add(new IdentityRole("comum"));
                db.SaveChanges();
            }

            if (!db.Roles.Any(r => r.Name == "vendedor"))
            {
                db.Roles.Add(new IdentityRole("vendedor"));
                db.SaveChanges();
            }
        }
    }

    private static void AddJWTConfiguration(IServiceCollection services, 
                                            IConfiguration configuration)
    {
        // Configurando JWT
        var appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<JwtAppSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<JwtAppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings?.Secret ?? string.Empty);

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, bearerOpts => {

            bearerOpts.RequireHttpsMetadata = true;
            bearerOpts.SaveToken = true;
            bearerOpts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                ValidAudience = appSettings?.Audience,
                ValidIssuer = appSettings?.Issuer
            };
        });
    }
}
