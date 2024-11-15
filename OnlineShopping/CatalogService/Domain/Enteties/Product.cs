using OnlineShopping.CatalogService.Domain.Common;

namespace OnlineShopping.CatalogService.Domain.Enteties;

public class Product : BaseEntity
{
    private string? name;
    private string? url;
    private decimal price;

    public required string Name 
    { 
        get => name!;
        set
        {
            if (name != value)
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
    }
    public string? Description { get; set; }
    public string? Url 
    { 
        get => url;
        set
        {
            if (url != value)
            {
                url = value;
                NotifyPropertyChanged();
            }
        }
    }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public decimal Price 
    {
        get => price;
        set
        {
            if (price != value)
            {
                price = value;
                NotifyPropertyChanged();
            }
        }
    }
    public int Amount { get; set; }
}
