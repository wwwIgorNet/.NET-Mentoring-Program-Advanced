namespace OnlineShopping.CartService.WebApi.DAL.Entities;

public class CartItem
{
    public int Id { get; set; }
    public required string CartId { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
    public required decimal Price { get; set; }
    public int Quantity { get; set; }
}
