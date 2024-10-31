using AutoMapper;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Categories.Queries;

public class CategoryDto
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
    public int? ParentCategoryId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, Category>();
        }
    }
}
