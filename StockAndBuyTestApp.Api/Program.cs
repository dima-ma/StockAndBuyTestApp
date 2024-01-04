using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockAndBuyTestApp.Api.Common.Mapping;
using StockAndBuyTestApp.Application.Common.Interfaces.Persistance;
using StockAndBuyTestApp.Application.Products.Commands.CreateProduct;
using StockAndBuyTestApp.Infrastructure.Persistance;
using StockAndBuyTestApp.Infrastructure.Persistance.Interceptors;
using StockAndBuyTestApp.Infrastructure.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommandHandler).Assembly));

builder.Services.AddDbContext<StockAndBuyDbContext>(
    cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBundleRepository, BundleRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IBundleToProductRepository, BundleToProductRepository>();
builder.Services.AddScoped<IBundleToBundleRepository, BundleToBundleRepository>();
builder.Services.AddScoped<PublishDomainEventInterceptor>();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductMappingProfile());
    mc.AddProfile(new BundleMappingProfile());
    mc.AddProfile(new StockMappingProflie());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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