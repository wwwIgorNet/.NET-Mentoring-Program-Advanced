using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using OnlineShopping.CatalogService.Application.Common.Interfaces;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Application.Categories.Queries;

public record GetCategoryCommand(int Id) : IRequest<CategoryDto>;

public class GetCategoryCommandHandler(IReadOnlyRepository<Category> repository, IMapper mapper)
    : IRequestHandler<GetCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.TryGetAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        return mapper.Map<CategoryDto>(entity);
    }
}
