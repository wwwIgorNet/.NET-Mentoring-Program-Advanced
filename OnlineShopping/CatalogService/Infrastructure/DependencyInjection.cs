using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;
using OnlineShopping.CatalogService.Infrastructure.Repositories;

namespace OnlineShopping.CatalogService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, DispatchDomainEvents>();

        services.AddTransient<IRepository<OutboxMessage>, OutboxMessageRepository>();

        services.AddTransient<IRepository<Category>, RepositoryBase<Category>>();
        services.AddTransient<IReadOnlyRepository<Category>, ReadOnlyRepository<Category>>();

        services.AddTransient<IRepository<Product>, RepositoryBase<Product>>();
        services.AddTransient<IReadOnlyRepository<Product>, ReadOnlyRepository<Product>>();

        return services;
    }
}
