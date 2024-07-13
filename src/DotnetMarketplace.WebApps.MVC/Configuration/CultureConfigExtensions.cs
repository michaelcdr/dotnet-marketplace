using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace DotnetMarketplace.WebApps.MVC.Configuration
{
    public static class CultureConfigExtensions
    {
        public static IApplicationBuilder UseCultureInfoConfigurations(this IApplicationBuilder app)
        {
            var defaultCulture = new CultureInfo("pt-BR");

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            });
            return app;
        }
    }
}
