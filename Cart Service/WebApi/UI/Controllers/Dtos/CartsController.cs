using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.DAL.Entities;
using OnlineShopping.CartService.WebApi.UI.Controllers.Dtos;

namespace OnlineShopping.CartService.WebApi.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController(ILogger<CartsController> logger,
            ICartItemsService _cartItemsService,
            IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CartItemDto> Get([FromQuery] string cartId)
        {
            return mapper.Map<IEnumerable<CartItemDto>>(_cartItemsService.FindItems(cartId));
        }

        [HttpPut]
        public int Add([FromBody] AddCartItemDto cartItem)
        {
            return _cartItemsService.Insert(mapper.Map<CartItem>(cartItem));
        }

        [HttpDelete]
        public bool Delete([FromBody] int cartItemId)
        {
            return _cartItemsService.Delete(cartItemId);
        }
    }
}
