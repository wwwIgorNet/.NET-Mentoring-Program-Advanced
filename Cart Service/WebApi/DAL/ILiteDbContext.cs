using LiteDB;

namespace OnlineShopping.CartService.WebApi.DAL;

public interface ILiteDbContext
{
    ILiteDatabase Database { get; }
}