using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.CatalogService.Application.Products.Commands;
using OnlineShopping.CatalogService.Application.Products.Queries;
using OnlineShopping.CatalogService.Domain.Constants;
using OnlineShopping.CatalogService.WebApi.Controllers.Models;

namespace OnlineShopping.CatalogService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ISender sender) 
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Read)]
    public async Task<IActionResult> ListAsync([FromQuery] GetProductsWithPaginationQuery query)
    {
        return Ok(await sender.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Read)]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        Response.Headers.Append("Allow", "GET,POST,PUT,DELETE");

        var product = await sender.Send(new GetProductQuery(id));

        List<LinkInfo> links =
        [
            new LinkInfo(Url.Action(nameof(GetAsync), new { id }), "self", "GET"),
            new LinkInfo(Url.Action(nameof(UpdateAsync), new { id }), "update_product", "PUT"),
            new LinkInfo(Url.Action(nameof(DeleteAsync), new { id }), "delete_product", "DELETE")
        ];

        return Ok(new
        {
            Product = product,
            Links = links
        });
    }


    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Create)]
    public async Task<IActionResult> AddAsync(CreateProductCommand command)
    {
        var id = await sender.Send(command);
        var dto = await sender.Send(new GetProductQuery(id));
        return CreatedAtAction(nameof(GetAsync), new { id }, dto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = Policies.Edit)]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateProductCommand command)
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
    public async Task<IActionResult> DeleteAsync(DeleteProductCommand command)
    {
        await sender.Send(command);

        return Ok();
    }
}
