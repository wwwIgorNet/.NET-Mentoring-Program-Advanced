using Ardalis.GuardClauses;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Categories.Commands;

public record DeleteCategoryCommand(int  Id) : IRequest;

public class DeleteCategoryCommandHandler (IRepository<Category> repository)
    : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.TryGetAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        await repository.TryDeleteAsync(entity);
    }
}
