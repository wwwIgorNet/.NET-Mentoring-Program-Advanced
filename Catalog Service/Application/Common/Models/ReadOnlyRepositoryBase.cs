using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Common;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Application.Common.Models;

public abstract class ReadOnlyRepositoryBase<TEntity>(IQueryable<TEntity> source)
    : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
{
    public virtual async Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, TOrderBy>>? orderBy = null,
        IConfigurationProvider? configuration = null,
        PagingOptions? pagingOptions = null)
        where TDestination : class
    {
        var query = source;
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (orderBy is not null)
        {
            query = query.OrderBy(orderBy);
        }

        var count = await Task.Run(source.Count);
        var pageNumber = 1;
        var pageSize = count;
        if (pagingOptions is not null)
        {
            pageNumber = pagingOptions.PageNumber;
            pageSize = pagingOptions.PageSize;
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        IQueryable<TDestination> targetResalt = query.ProjectTo<TDestination>(configuration);

        return new PaginatedList<TDestination>(await Task.Run(targetResalt.ToList), count, pageNumber, pageSize);
    }

    public abstract Task<TEntity?> TryGetAsync(int id);
}
