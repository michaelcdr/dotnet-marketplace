namespace DotnetMarketplace.Auth.API.Configuration
{
    public static class APIConfig
    {
        public static void ApplyAPIConfig(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void UseAPIConfig(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }

    }
}
