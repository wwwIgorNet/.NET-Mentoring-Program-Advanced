using OnlineShopping.CartService.WebApi.DAL.Entities;

namespace OnlineShopping.CartService.WebApi.DAL;

public interface ICartItemsRepository
{
    IEnumerable<CartItem> FindItems(string cartId);

    int Insert(CartItem cartItem);
    bool Update(CartItem cartItem);

    bool Delete(int id);
    IEnumerable<CartItem> GetByEntetyId(int entetyId);
}
