using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.CatalogService.Application.Categories.Commands;
using OnlineShopping.CatalogService.Application.Categories.Queries;
using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Infrastructure.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController(ApplicationDbContext applicationDbContext,
        ISender sender) : ControllerBase
    {
        [HttpGet]
        public Task<PaginatedList<CategoryDto>> List([FromQuery] GetCategoriesWithPaginationQuery query)
        {
            return sender.Send(query);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetCategoryCommand command)
        {
            return Ok(await sender.Send(command));
        }


        [HttpPut]
        public async Task<IActionResult> Add(CreateCategoryCommand command)
        {
            return Ok(await sender.Send(command));
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
           await sender.Send(command);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
        {
            await sender.Send(command);

            return Ok();
        }
    }
}
