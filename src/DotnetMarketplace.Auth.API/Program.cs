using DotnetMarketplace.Auth.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services
    .AddIdentityConfig(builder.Configuration)
    .AddAPIConfig(builder.Configuration, builder.Environment)
    .AddServicesConfig()
    .AddSwaggerConfig();

var app = builder.Build();
app.UseSwaggerConfig(app.Environment)
   .UseAPIConfig(app.Environment); 

app.Run();