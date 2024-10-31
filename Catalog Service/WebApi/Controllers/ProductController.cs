using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.CatalogService.Application.Products.Commands;
using OnlineShopping.CatalogService.Application.Products.Queries;

namespace OnlineShopping.CatalogService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController(ISender sender) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] GetProductsWithPaginationQuery query)
    {
        return Ok(await sender.Send(query));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductQuery command)
    {
        return Ok(await sender.Send(command));
    }


    [HttpPut]
    public async Task<IActionResult> Add(CreateProductCommand command)
    {
        return Ok(await sender.Send(command));
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductCommand command)
    {
        await sender.Send(command);
        return Ok();
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductCommand command)
    {
        await sender.Send(command);

        return Ok();
    }
}
