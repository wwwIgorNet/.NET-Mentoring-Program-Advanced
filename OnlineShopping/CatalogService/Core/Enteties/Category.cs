namespace OnlineShopping.CatalogService.Core.Enteties;

public class Category
{
    public required string Name { get; set; }
    public string? Image { get; set; }
    public int ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
