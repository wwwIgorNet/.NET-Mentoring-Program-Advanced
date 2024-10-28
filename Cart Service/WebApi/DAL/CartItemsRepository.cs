using LiteDB;
using OnlineShopping.CartService.WebApi.DAL.Entities;

namespace OnlineShopping.CartService.WebApi.DAL;

public class CartItemsRepository : ICartItemsRepository
{
    private readonly ILiteDatabase _liteDb;

    public CartItemsRepository(ILiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
    }

    public IEnumerable<CartItem> FindItems(string cartId)
    {
        return _liteDb.GetCollection<CartItem>("CartItems")
            .Find(x => x.CartId == cartId);
    }

    public int Insert(CartItem cartItem)
    {
        return _liteDb.GetCollection<CartItem>("CartItems")
            .Insert(cartItem).AsInt32;
    }

    public bool Delete(int id)
    {
        return _liteDb.GetCollection<CartItem>("CartItems")
            .Delete(new BsonValue(id));
    }
}
