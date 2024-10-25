using OnlineShopping.CatalogService.Domain.Common;

namespace OnlineShopping.CatalogService.Domain.Enteties;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public string? Image { get; set; }
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public IEnumerable<Category> ChildCategories { get; set; }
    public IEnumerable<Product> Products { get; set; }
}

