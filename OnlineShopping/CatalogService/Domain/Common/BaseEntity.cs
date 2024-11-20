using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace OnlineShopping.CatalogService.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }

    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var epce = typeof(EntityPropertyChangedEvent<>);
        var selfType = GetType();
        var property = selfType.GetProperty(propertyName)!;
        var propertyValue = property.GetValue(this);

        var makeme = epce.MakeGenericType([selfType]);
        var @event = Activator.CreateInstance(makeme, [this, propertyName, propertyValue]) as BaseEvent;

        AddDomainEvent(@event!);
    }
}
