using OnlineShopping.CartService.WebApi.DAL.Entities;

namespace OnlineShopping.CartService.WebApi.BLL
{
    public interface ICartItemsService
    {
        bool Delete(int id);
        IEnumerable<CartItem> FindItems(string cartId);
        CartItem? FindItem(string cartId, int itemId);
        int Insert(CartItem cartItem);
        void UpdateProperty(int entetyId, string propertyName, string newValue);
    }
}