using OnlineShopping.CatalogService.Domain.Common;

namespace OnlineShopping.CatalogService.Application.Common.Interfaces;

public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity);    
    Task<bool> TryUpdateAsync(TEntity entity);
    Task<bool> TryDeleteAsync(TEntity entity);
}
