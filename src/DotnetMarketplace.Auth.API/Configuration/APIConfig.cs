namespace DotnetMarketplace.Auth.API.Configuration;

public static class APIConfig
{
    public static IServiceCollection AddAPIConfig(this IServiceCollection services,                                             
                                                  ConfigurationManager configuration,
                                                  IWebHostEnvironment environment)
    {
        configuration
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        if (environment.IsDevelopment())
        {
            configuration.AddUserSecrets<Program>();
        }

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IApplicationBuilder UseAPIConfig(this IApplicationBuilder app, IWebHostEnvironment hostEnvironment)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseIdentity();

        app.UseEndpoints(endpo =>
        {
            endpo.MapControllers();
        });

        return app;
    }

}