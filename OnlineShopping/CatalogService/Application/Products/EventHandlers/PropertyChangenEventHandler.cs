using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Common;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Products.EventHandlers;

public class PropertyChangenEventHandler(IRepository<OutboxMessage> Repository)
    : INotificationHandler<EntityPropertyChangedEvent<Product>>
{
    public async Task Handle(EntityPropertyChangedEvent<Product> notification, CancellationToken cancellationToken)
    {
        if (notification.Entity.Id <= 0)
            return;

        var @event = new OutboxMessage
        {
            Property = $"{notification.Entity.GetType().Name}.{notification.Property}",
            NewValue = $"{notification.Value}",
            CreationTime = DateTimeOffset.UtcNow
        };
        await Repository.AddAsync(@event);
    }
}
