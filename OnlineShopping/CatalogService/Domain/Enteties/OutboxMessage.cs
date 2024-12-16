using OnlineShopping.CatalogService.Domain.Common;

namespace OnlineShopping.CatalogService.Domain.Enteties;

public class OutboxMessage : BaseEntity
{
    public int EntetyId { get; set; }
    public required string Property { get; set; }
    public required string NewValue { get; set; }
    public DateTimeOffset CreationTime { get; set; }
    public DateTimeOffset? CompleteTime { get; set; }
}
