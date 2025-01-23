using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.BLL.Constants;
using OnlineShopping.CartService.WebApi.DAL.Entities;
using OnlineShopping.CartService.WebApi.UI.Controllers.Dtos;

namespace OnlineShopping.CartService.WebApi.UI.Controllers;

[ApiController]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/carts")]
[Authorize(Policy = Policies.CRUD)]
public class CartItemsController(
        ICartItemsService _cartItemsService,
        IMapper mapper) : ControllerBase
{
    [HttpGet("{cartId}/items")]
    [MapToApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetItems([FromRoute, BindRequired] string cartId)
    {
        var items = _cartItemsService.FindItems(cartId);
        var itemsDto = mapper.Map<IEnumerable<CartItemDto>>(items);
        return Ok(new { CartId = cartId, Items = itemsDto });
    }

    [HttpGet("{cartId}/items")]
    [MapToApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetItemsV2([FromRoute, BindRequired] string cartId)
    {
        var items = _cartItemsService.FindItems(cartId);
        var itemsDto = mapper.Map<IEnumerable<CartItemDto>>(items);
        return Ok(itemsDto);
    }

    [HttpGet("{cartId}/items/{itemId}")]
    [ProducesResponseType<CartItemDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetItem([FromRoute, BindRequired] string cartId, [FromRoute, BindRequired] int itemId)
    {
        var item = _cartItemsService.FindItem(cartId, itemId);
        if (item is null) 
            return NotFound(); 

        return Ok(mapper.Map<CartItemDto>(item));
    }

    [HttpPost("{cartId}/items")]
    [ProducesResponseType<int>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Add([FromRoute, BindRequired] string cartId, [FromBody, BindRequired] AddCartItemDto cartItem)
    {
        var itemId = _cartItemsService.Insert(mapper.Map<CartItem>(cartItem));
        var item = _cartItemsService.FindItem(cartId, itemId);
        return CreatedAtAction(nameof(GetItem), new { cartId, itemId }, mapper.Map<CartItemDto>(item));
    }

    [HttpDelete("{cartid}/items/{itemId}")]
    [ProducesResponseType<CartItemDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete([FromRoute, BindRequired] string cartId, [FromRoute, BindRequired] int itemId)
    {
        var item = _cartItemsService.FindItem(cartId, itemId);
        if (item is null)
            return NotFound();

        _cartItemsService.Delete(itemId);
        return Ok();
    }
}
