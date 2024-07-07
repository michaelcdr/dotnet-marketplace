using DotnetMarketplace.Auth.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddAPIConfig(builder.Configuration, builder.Environment);
builder.Services.AddServicesConfig();
builder.Services.AddSwaggerConfig();

var app = builder.Build();
app.UseAPIConfig(app.Environment);
app.UseSwaggerConfig(app.Environment);
app.Run();