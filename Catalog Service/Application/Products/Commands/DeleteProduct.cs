using Ardalis.GuardClauses;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Products.Commands;

public record DeleteProductCommand(int Id) : IRequest;

public class DeleteProductCommandHandler(IRepository<Product> repository)
    : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.TryGetAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        await repository.TryDeleteAsync(entity);
    }
}

