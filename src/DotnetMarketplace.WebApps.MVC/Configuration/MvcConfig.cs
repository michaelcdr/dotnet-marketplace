using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.WebApps.MVC.Configuration;

public static class MvcConfig
{
    public static IServiceCollection AddMvcConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

        }).AddRazorRuntimeCompilation();

        services.Configure<AppSettings>(configuration);

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