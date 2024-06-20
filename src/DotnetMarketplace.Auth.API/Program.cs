using DotnetMarketplace.Auth.API.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ApplyAPIConfig();
builder.Services.ApplyIdentityConfig(builder.Configuration?.GetConnectionString("DefaultConnection"));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseAPIConfig();

app.Run();