using LiteDB;
using OnlineShopping.CartService.WebApi.DAL;
using OnlineShopping.CartService.WebApi.DAL.Entities;

namespace OnlineShopping.CartService.WebApi.BLL
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ILiteDatabase _liteDb;

        public CartItemsService(ILiteDbContext liteDbContext)
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
}
