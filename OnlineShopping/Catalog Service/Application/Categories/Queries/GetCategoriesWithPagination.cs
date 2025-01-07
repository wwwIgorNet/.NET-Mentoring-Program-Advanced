using AutoMapper;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Categories.Queries;

public record GetCategoriesWithPaginationQuery : IRequest<PaginatedList<CategoryDto>>
{
    public int? ParentCategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCategoriesWithPaginationQueryHandler(IReadOnlyRepository<Category> repository, IMapper mapper) 
    : IRequestHandler<GetCategoriesWithPaginationQuery, PaginatedList<CategoryDto>>
{

    public async Task<PaginatedList<CategoryDto>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var page = await repository.List<string, CategoryDto>(
            c => c.ParentCategoryId == request.ParentCategoryId, 
            p => p.Name, 
            mapper.ConfigurationProvider,
            new PagingOptions(request.PageNumber, request.PageSize));

        return page;
    }
}
