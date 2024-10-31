using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Categories.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public required string Name { get; set; }
    public string? Image { get; set; }
    public int? ParentCategoryId { get; set; }
}

public class CreateCategoryCommandHandler(IRepository<Category> repository)
    : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entety = new Category
        {
            Name = request.Name,
            Image = request.Image,
            ParentCategoryId = request.ParentCategoryId
        };
        await repository.AddAsync(entety);

        return entety.Id;
    }
}
