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

        public CartItem? FindItem(string cartId, int itemId)
        {
            return _repository.FindItems(cartId).FirstOrDefault(i => i.Id == itemId);
        }

        public int Insert(CartItem cartItem)
        {
            return _repository.Insert(cartItem);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public void UpdateProperty(int externalEntityId, string propertyName, string newValue)
        {
            var cartItems = _repository.GetByEntetyId(externalEntityId);
            foreach (var cartItem in cartItems) {
                switch (propertyName)
                {
                    case "Name":
                        cartItem.Name = newValue;
                        break;
                    case "Image":
                        cartItem.Image = newValue;
                        break;
                    case "Price":
                        cartItem.Price = int.Parse(newValue);
                        break;
                }
                _repository.Update(cartItem);
            }
        }
    }
}
