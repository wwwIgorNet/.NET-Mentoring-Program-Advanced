using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Enteties;
using OnlineShopping.CatalogService.Infrastructure.Data;

namespace OnlineShopping.CatalogService.Infrastructure.Repositories
{
    internal class CategoryRepository : ReadOnlyRepositoryBase<Category>, IRepository<Category>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext dbContext,
            IMapper mapper)
            : base(dbContext.Categories)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(Category entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> TryDeleteAsync(Category entity)
        {
            var res = _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public override Task<Category?> TryGetAsync(int id)
        {
            return _dbContext.Categories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> TryUpdateAsync(Category entity)
        {
            var res = await _dbContext.Categories.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (res == null) { return false; }

            _mapper.Map(entity, res);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
