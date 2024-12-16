using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Common;
using OnlineShopping.CatalogService.Infrastructure.Data;

namespace OnlineShopping.CatalogService.Infrastructure.Repositories;

public class RepositoryBase<TEntity>
    : ReadOnlyRepositoryBase<TEntity>, IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _entities;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RepositoryBase(ApplicationDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork)
        : base(dbContext.Set<TEntity>())
    {
        _entities = dbContext.Set<TEntity>();
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> TryDeleteAsync(TEntity entity)
    {
        var res = _entities.Remove(entity);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> TryUpdateAsync(TEntity entity)
    {
        var res = await _entities.FirstOrDefaultAsync(e => e.Id == entity.Id);
        if (res == null) { return false; }

        _mapper.Map(entity, res);
        await _unitOfWork.SaveChangesAsync();
        return true;

    }
}
