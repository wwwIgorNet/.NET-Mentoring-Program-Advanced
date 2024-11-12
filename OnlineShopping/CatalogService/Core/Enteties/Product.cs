namespace OnlineShopping.CatalogService.Core.Enteties;

public class Product
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
