using AutoMapper;
using OnlineShopping.CatalogService.Application.Common.Models;
using System.Linq.Expressions;

namespace OnlineShopping.CatalogService.Application.Common.Interfaces;

public interface IRepository<TEntety>
{
    Task Add(TEntety entety);
    Task<PaginatedList<TDestination>> List<TOrderBy, TDestination>(
        Expression<Func<TEntety, bool>>? predicate = null,
        Expression<Func<TEntety, TOrderBy>>? orderBy = null,
        IConfigurationProvider? configuration = null,
        PagingOptions? pagingOptions = null) where TDestination : class;
    Task<TEntety> Get(int entetyId);
    Task Update(TEntety entetyp);
    Task Delete(TEntety entety);
}
