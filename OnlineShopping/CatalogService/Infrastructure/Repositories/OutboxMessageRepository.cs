using AutoMapper;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Enteties;
using OnlineShopping.CatalogService.Infrastructure.Data;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Infrastructure.Repositories;

internal class OutboxMessageRepository : IRepository<OutboxMessage>
{
    private readonly ApplicationDbContext _dbContext;
    public OutboxMessageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(OutboxMessage entity)
    {
        await _dbContext.OutboxMessages.AddAsync(entity);
    }

    public Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(Expression<Func<OutboxMessage, bool>>? predicate = null, Expression<Func<OutboxMessage, TOrderBy>>? orderBy = null, IConfigurationProvider? configuration = null, PagingOptions? pagingOptions = null) where TDestination : class
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryDeleteAsync(OutboxMessage entity)
    {
        throw new NotImplementedException();
    }

    public Task<OutboxMessage?> TryGetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryUpdateAsync(OutboxMessage entity)
    {
        throw new NotImplementedException();
    }
}
