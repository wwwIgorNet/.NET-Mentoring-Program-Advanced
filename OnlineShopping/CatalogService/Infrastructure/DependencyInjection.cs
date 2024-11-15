using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;
using OnlineShopping.CatalogService.Infrastructure.Data;
using OnlineShopping.CatalogService.Infrastructure.Repositories;

namespace OnlineShopping.CatalogService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddTransient<IRepository<Category>, RepositoryBase<Category>>();
        services.AddTransient<IReadOnlyRepository<Category>, ReadOnlyRepository<Category>>();

        services.AddTransient<IRepository<Product>, RepositoryBase<Product>>();
        services.AddTransient<IReadOnlyRepository<Product>, ReadOnlyRepository<Product>>();

        return services;
    }
}
