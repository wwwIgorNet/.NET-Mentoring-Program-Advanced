using Microsoft.EntityFrameworkCore;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Common;
using OnlineShopping.CatalogService.Infrastructure.Data;

namespace OnlineShopping.CatalogService.Infrastructure.Repositories;

internal class ReadOnlyRepository<TEntity> 
    : ReadOnlyRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    public ReadOnlyRepository(ApplicationDbContext dbContext)
        :base(dbContext.Set<TEntity>().AsNoTracking())
    {
        
    }
}
