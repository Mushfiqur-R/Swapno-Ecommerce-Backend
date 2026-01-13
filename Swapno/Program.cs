using AutoMapper;
using BLL;
using BLL.Services;
using DAL;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DataAccessFactory>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<CategoryService>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<SwapnoDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBCS")
        )
      );

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MapperConfig>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
