using AutoMapper;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Products.Queries;

public class GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductDto>>
{
    public int CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductsWithPaginationQueryHandler(IReadOnlyRepository<Product> repository, IMapper mapper)
    : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductDto>>
{
    public async Task<PaginatedList<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var page = await repository.List<string, ProductDto>(
            p => p.CategoryId == request.CategoryId,
            p => p.Name,
            mapper.ConfigurationProvider,
            new PagingOptions(request.PageNumber, request.PageSize));

        return page;
    }
}
