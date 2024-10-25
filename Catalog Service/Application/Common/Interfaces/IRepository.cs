using AutoMapper;
using OnlineShopping.CatalogService.Application.Common.Models;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Application.Common.Interfaces;

public interface IRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, TOrderBy>>? orderBy = null,
        IConfigurationProvider? configuration = null,
        PagingOptions? pagingOptions = null) where TDestination : class;
    Task<TEntity?> TryGetAsync(int id);
    Task<bool> TryUpdateAsync(TEntity entity);
    Task<bool> TryDeleteAsync(TEntity entity);
}
