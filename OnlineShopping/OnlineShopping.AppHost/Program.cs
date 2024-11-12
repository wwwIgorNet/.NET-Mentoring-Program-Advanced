var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache");

var cartServiceApi = builder.AddProject<Projects.OnlineShopping_CartService_WebApi>("CartServiceApi");
var catalogServiceApi = builder.AddProject<Projects.OnlineShopping_CatalogService_WebApi>("CatalogServiceApi");



builder.Build().Run();
 