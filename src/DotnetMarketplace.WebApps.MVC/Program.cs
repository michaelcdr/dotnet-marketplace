using DotnetMarketplace.Catalog.Data.Data;
using DotnetMarketplace.WebApps.MVC.Configuration;
using DotnetMarketPlace.ContentManager.Data.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connStr = builder.Configuration?.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddIdentityConfigs();
builder.Services.AddMvcConfig();

builder.Services.AddDbContext<ContentManagerContext>(options => options.UseSqlServer(connStr));
builder.Services.AddDbContext<CatalogContext>(options => options.UseSqlServer(connStr));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.RegisterServices();

var app = builder.Build();
app.UseMvcConfig();
app.Run();