namespace OnlineShopping.CatalogService.Domain.Common;

public class EntityPropertyChangedEvent<TEntity> : BaseEvent
    where TEntity : BaseEntity
{
    public EntityPropertyChangedEvent(TEntity entity, string property, object value)
    {
        Entity = entity;
        Property = property;
        Value = value;
    }

    public TEntity Entity { get; }
    public string Property { get; }
    public object Value { get; }
}
