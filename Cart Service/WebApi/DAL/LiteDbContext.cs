using LiteDB;
using Microsoft.Extensions.Options;

namespace OnlineShopping.CartService.WebApi.DAL;

public class LiteDbContext : ILiteDbContext
{
    public ILiteDatabase Database { get; }

    public LiteDbContext(IOptions<LiteDbOptions> options)
    {
        Database = new LiteDatabase(options.Value.DatabaseLocation);
    }
}
