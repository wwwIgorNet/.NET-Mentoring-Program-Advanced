using OnlineShopping.CartService.WebApi.DAL.Entities;

namespace OnlineShopping.CartService.WebApi.BLL
{
    public interface ICartItemsService
    {
        bool Delete(int id);
        IEnumerable<CartItem> FindItems(string cartId);
        int Insert(CartItem cartItem);
    }
}