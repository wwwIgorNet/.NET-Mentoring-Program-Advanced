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
public class CategoriesController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Read)]
    public async Task<IActionResult> List([FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return Ok(await sender.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Read)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        Response.Headers.Append("Allow", "GET,POST,PUT,DELETE");
        var category = await sender.Send(new GetCategoryCommand(id));
        List<LinkInfo> links =
        [
            new LinkInfo(Url.Action(nameof(Get), new { id }), "self", "GET"),
            new LinkInfo(Url.Action(nameof(Update), new { id }), "update_category", "PUT"),
            new LinkInfo(Url.Action(nameof(Delete), new { id }), "delete_category", "DELETE")
        ];

        return Ok(new
        {
            Category = category,
            Links = links
        });
    }


    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Create)]
    public async Task<IActionResult> Add(CreateCategoryCommand command)
    {
        var id = await sender.Send(command);
        var dto = await sender.Send(new GetCategoryCommand(id));
        return CreatedAtAction(nameof(Get), new { id },dto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Edit)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryCommand command)
    {
        command.Id = id;
        await sender.Send(command);
        return Ok();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await sender.Send(new DeleteCategoryCommand(id));
        return Ok();
    }
}
