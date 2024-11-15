using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Common;
using OnlineShopping.CatalogService.Infrastructure.Data;

namespace OnlineShopping.CatalogService.Infrastructure.Repositories;

public class DispatchDomainEvents(ApplicationDbContext dbContext,
    IMediator mediator)
    : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = dbContext.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);

        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
