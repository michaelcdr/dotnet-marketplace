using Microsoft.EntityFrameworkCore;
using MKT.Catalog.API.Models.Services;
using MKT.Catalog.API.Services;
using MKT.Catalog.Domain.Repositories;
using MKT.Catalog.Infra.Data;
using MKT.Catalog.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration?.AddUserSecrets<Program>();
}

string connStr = builder.Configuration?.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<CatalogContext>(options => options.UseSqlServer(connStr));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
