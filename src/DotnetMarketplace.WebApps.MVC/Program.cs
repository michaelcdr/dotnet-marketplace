using DotnetMarketplace.WebApps.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMvcConfig(builder.Configuration)
    .AddIdentityConfigs()
    .RegisterServices();

var app = builder.Build();
app.UseMvcConfig();
app.Run();