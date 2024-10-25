using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Products.Queries;

public record GetProductQuery(int Id) : IRequest<ProductDto>;

public class GetProductQueryHandler(IReadOnlyRepository<Product> repository, IMapper mapper)
    : IRequestHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.TryGetAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        return mapper.Map<ProductDto>(entity);
    }
}
