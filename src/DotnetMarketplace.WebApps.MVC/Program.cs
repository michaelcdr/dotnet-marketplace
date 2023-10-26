using DotnetMarketplace.Catalog.Application.Services;
using DotnetMarketplace.Catalog.Data.Data;
using DotnetMarketplace.Catalog.Data.Repositories;
using DotnetMarketplace.Catalog.Domain.Repositories;
using DotnetMarketplace.WebApps.MVC.Configuration;
using DotnetMarketPlace.ContentManager.Data.Data;
using DotnetMarketPlace.ContentManager.Data.Repositories;
using DotnetMarketPlace.ContentManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContentManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<CatalogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ICarouselRepository, CarouselRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
