using DotnetMarketplace.Auth.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Auth.API.Configuration
{
    public static class IdentityConfig
    {
        public static void ApplyIdentityConfig(this IServiceCollection services, string? connStr)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connStr));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    
    }
}
