using OnlineShopping.CartService.WebApi.DAL;
using OnlineShopping.CartService.WebApi.DAL.Entities;

namespace OnlineShopping.CartService.WebApi.BLL
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemsRepository _repository;

        public CartItemsService(ICartItemsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CartItem> FindItems(string cartId)
        {
            return _repository.FindItems(cartId);
        }

        public int Insert(CartItem cartItem)
        {
            return _repository.Insert(cartItem);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
