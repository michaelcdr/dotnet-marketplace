namespace DotnetMarketplace.WebApps.MVC.Configuration
{
    public static class MvcConfig
    {
        public static void AddMvcConfig(this IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public static void UseMvcConfig(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCultureInfoConfigurations();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityConfigs();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        }
    }
}
