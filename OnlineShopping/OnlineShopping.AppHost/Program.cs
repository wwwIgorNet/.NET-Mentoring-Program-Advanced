var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache");

var username = builder.AddParameter("RabbitMQUser", secret: true);
var password = builder.AddParameter("RabbitMQPassword", secret: true);
var rabbitmq = builder.AddRabbitMQ("messaging", username, password)
    .WithDataBindMount(source: @"..\RabbitMQ\Data", isReadOnly: false)
    .WithManagementPlugin();

var cartServiceApi = builder.AddProject<Projects.OnlineShopping_CartService_WebApi>("CartServiceApi")
    .WithReference(rabbitmq);

var catalogServiceApi = builder.AddProject<Projects.OnlineShopping_CatalogService_WebApi>("CatalogServiceApi")
    .WithReference(rabbitmq);

builder.Build().Run();
 