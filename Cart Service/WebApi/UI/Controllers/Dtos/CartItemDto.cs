namespace OnlineShopping.CartService.WebApi.UI.Controllers.Dtos
{
    public class CartItemDto
    {
        public int? Id { get; set; }
        public required string CartId { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public required decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
