using Microsoft.EntityFrameworkCore;
using MKT.ContentManager.Data.Data;
using MKT.ContentManager.Data.Repositories;
using MKT.ContentManager.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration?.AddUserSecrets<Program>();
}

string connStr = builder.Configuration?.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<ContentManagerContext>(options => options.UseSqlServer(connStr));
builder.Services.AddScoped<ICarouselRepository, CarouselRepository>();

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
