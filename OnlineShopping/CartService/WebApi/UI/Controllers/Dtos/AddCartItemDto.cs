namespace OnlineShopping.CartService.WebApi.UI.Controllers.Dtos;

public class AddCartItemDto
{
    public required string CartId { get; set; }
    public int ExternalEntityId { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
    public required decimal Price { get; set; }
    public int Quantity { get; set; }
}
