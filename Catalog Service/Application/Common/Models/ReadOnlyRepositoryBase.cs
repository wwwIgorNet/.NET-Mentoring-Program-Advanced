using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Common;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Application.Common.Models;

public class ReadOnlyRepositoryBase<TEntity>
    : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly IQueryable<TEntity> _source;

    public ReadOnlyRepositoryBase(IQueryable<TEntity> source)
    {
        _source = source;
    }

    public virtual async Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, TOrderBy>>? orderBy = null,
        IConfigurationProvider? configuration = null,
        PagingOptions? pagingOptions = null)
        where TDestination : class
    {
        var query = _source;
        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (orderBy is not null)
        {
            query = query.OrderBy(orderBy);
        }

        var count = await Task.Run(_source.Count);
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

    public Task<TEntity?> TryGetAsync(int id)
    {
        return Task.Run(() => _source.FirstOrDefault(x => x.Id == id));
    }
}
