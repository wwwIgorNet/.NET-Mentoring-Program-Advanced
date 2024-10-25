using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Application.Common.Models;

public abstract class RepositoryBase<TEntety>(IQueryable<TEntety> source)
    : IRepository<TEntety>
{
    public abstract Task Add(TEntety entety);

    public virtual async Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(
        Expression<Func<TEntety, bool>>? predicate = null,
        Expression<Func<TEntety, TOrderBy>>? orderBy = null,
        IConfigurationProvider? configuration = null,
        PagingOptions? pagingOptions = null) where TDestination : class
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

        var count = source.Count();
        var pageNumber = 1;
        var pageSize = count;
        if (pagingOptions is not null)
        {
            pageNumber = pagingOptions.PageNumber;
            pageSize = pagingOptions.PageSize;
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        IQueryable<TDestination> targetResalt;
        if (configuration is not null)
        {
            targetResalt = query.ProjectTo<TDestination>(configuration);
        }
        else
        {
            targetResalt = query.Cast<TDestination>();
        }

        return new PaginatedList<TDestination>(targetResalt.ToList(), count, pageNumber, pageSize);
    }

    public abstract Task<TEntety> Get(int entetyId);

    public abstract Task Update(TEntety entetyp);

    public abstract Task Delete(TEntety entety);
}
