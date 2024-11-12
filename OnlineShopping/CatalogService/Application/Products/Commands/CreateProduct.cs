using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Products.Commands;

public class CreateProductCommand : IRequest<int>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}

public class CreateProductCommandHandler(IRepository<Product> repository)
    : IRequestHandler<CreateProductCommand, int>
{


    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entety = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Url = request.Url,
            CategoryId = request.CategoryId,
            Price = request.Price,
            Amount = request.Amount
        };

        await repository.AddAsync(entety);

        return entety.Id;
    }
}
