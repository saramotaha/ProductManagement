using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.Repositories;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(op=>op.UseInMemoryDatabase("ProductManagementDb"));

builder.Services.AddScoped<IProductRepository , ProductRepository>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateProductCommand))!)
);

builder.Services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();






var app = builder.Build();


var x = app.Services.CreateScope();
var db = x.ServiceProvider.GetRequiredService<AppDbContext>();
db.Categories.AddRange(
           new Category { Name = "Electronics", Description = "Phones, Laptops, etc." },
           new Category { Name = "Clothing", Description = "Shirts, Jeans, etc." },
           new Category { Name = "Books", Description = "Programming, Fiction, etc." }
       );
db.SaveChanges();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(option => option.SwaggerEndpoint("/openapi/v1.json", "v1"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
