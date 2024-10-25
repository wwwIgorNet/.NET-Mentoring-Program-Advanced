using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Categories.Commands;

public class UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
    public int? ParentCategoryId { get; set; }
}

public class UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper) 
    : IRequestHandler<UpdateCategoryCommand>
{
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.TryGetAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Image = request.Image;
        entity.ParentCategoryId = request.ParentCategoryId;

        await repository.TryUpdateAsync(entity);
    }
}

