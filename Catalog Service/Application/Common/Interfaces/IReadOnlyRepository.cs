using AutoMapper;
using OnlineShopping.CatalogService.Application.Common.Models;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Application.Common.Interfaces;

public interface IReadOnlyRepository<TEntity>
{
    Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, TOrderBy>>? orderBy = null,
        IConfigurationProvider? configuration = null,
        PagingOptions? pagingOptions = null) where TDestination : class;
    Task<TEntity?> TryGetAsync(int id);
}
