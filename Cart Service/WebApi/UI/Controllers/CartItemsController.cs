using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.DAL.Entities;
using OnlineShopping.CartService.WebApi.UI.Controllers.Dtos;

namespace OnlineShopping.CartService.WebApi.UI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1.0/carts")]
    public class CartItemsController(ILogger<CartItemsController> logger,
            ICartItemsService _cartItemsService,
            IMapper mapper) : ControllerBase
    {
        [HttpGet("{cartId}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetItems([FromQuery] string cartId)
        {
            var items = _cartItemsService.FindItems(cartId);
            var itemsDto = mapper.Map<IEnumerable<CartItemDto>>(items);
            return Ok(new { CartId = cartId, Items = itemsDto });
        }

        [HttpGet("{cartId}/items/{itemId}")]
        [ProducesResponseType(typeof(CartItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetItem([FromQuery] string cartId, [FromQuery] int itemId)
        {
            var item = _cartItemsService.FindItem(cartId, itemId);
            if (item is null) 
                return NotFound(); 

            return Ok(mapper.Map<CartItemDto>(item));
        }

        [HttpPost("{cartId}/items")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromQuery] string cartId, [FromBody] AddCartItemDto cartItem)
        {
            var itemId = _cartItemsService.Insert(mapper.Map<CartItem>(cartItem));
            var item = _cartItemsService.FindItem(cartId, itemId);
            return CreatedAtAction(nameof(GetItem), new { cartId, itemId }, mapper.Map<CartItemDto>(item));
        }

        [HttpDelete("{cartid}/items/{itemId}")]
        [ProducesResponseType(typeof(CartItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete([FromQuery] string cartId, [FromQuery] int itemId)
        {
            var item = _cartItemsService.FindItem(cartId, itemId);
            if (item is null)
                return NotFound();

            _cartItemsService.Delete(itemId);
            return Ok();
        }
    }
}
