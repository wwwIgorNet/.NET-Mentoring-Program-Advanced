using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.CatalogService.Application.Categories.Commands;
using OnlineShopping.CatalogService.Application.Categories.Queries;
using OnlineShopping.CatalogService.Domain.Constants;
using OnlineShopping.CatalogService.WebApi.Controllers.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CategoriesController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Policy = Policies.Read)]
    public async Task<IActionResult> ListAsync([FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return Ok(await sender.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Policy = Policies.Read)]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        Response.Headers.Append("Allow", "GET,POST,PUT,DELETE");
        var category = await sender.Send(new GetCategoryCommand(id));
        List<LinkInfo> links =
        [
            new LinkInfo(Url.Action(nameof(GetAsync), new { id }), "self", "GET"),
            new LinkInfo(Url.Action(nameof(UpdateAsync), new { id }), "update_category", "PUT"),
            new LinkInfo(Url.Action(nameof(DeleteAsync), new { id }), "delete_category", "DELETE")
        ];

        return Ok(new
        {
            Category = category,
            Links = links
        });
    }


    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [Authorize(Policy = Policies.Create)]
    public async Task<IActionResult> AddAsync(CreateCategoryCommand command)
    {
        var id = await sender.Send(command);
        var dto = await sender.Send(new GetCategoryCommand(id));
        return CreatedAtAction(nameof(GetAsync), new { id },dto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Policy = Policies.Edit)]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateCategoryCommand command)
    {
        command.Id = id;
        await sender.Send(command);
        return Ok();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Policy = Policies.Delete)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await sender.Send(new DeleteCategoryCommand(id));
        return Ok();
    }
}
