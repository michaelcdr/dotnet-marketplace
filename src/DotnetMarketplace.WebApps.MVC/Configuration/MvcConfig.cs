using DotnetMarketplace.Catalog.Data.Data;
using DotnetMarketPlace.ContentManager.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.WebApps.MVC.Configuration;

public static class MvcConfig
{
    public static IServiceCollection AddMvcConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

        }).AddRazorRuntimeCompilation();

        string connStr = configuration?.GetConnectionString("DefaultConnection") ?? string.Empty;
        services.AddDbContext<ContentManagerContext>(options => options.UseSqlServer(connStr));
        services.AddDbContext<CatalogContext>(options => options.UseSqlServer(connStr));
        return services;
    }

    public static void UseMvcConfig(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseCultureInfoConfigurations()
           .UseRouting()
           .UseHttpsRedirection()
           .UseStaticFiles()
           .UseIdentityConfigs();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}