using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Products.Commands;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}

public class UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.TryGetAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Url = request.Url;
        entity.CategoryId = request.CategoryId;
        entity.Price = request.Price;
        entity.Amount = request.Amount;

        await repository.TryUpdateAsync(entity);
    }
}
