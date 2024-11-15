var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache");

var rabbitMQUserName = builder.AddParameter("RabbitMQUser", secret: true);
var rabbitMQPassword = builder.AddParameter("RabbitMQPassword", secret: true);
var rabbitmq = builder.AddRabbitMQ("messaging", rabbitMQUserName, rabbitMQPassword)
    .WithDataVolume(@"data-rabbitMQ", isReadOnly: false)
    .WithManagementPlugin();

var sqlPassword = builder.AddParameter("MSSQLServerPassord", secret: true);
var sqlServer = builder.AddSqlServer("mssql", sqlPassword)
    .WithDataVolume("data-mssql", isReadOnly: false)
    .AddDatabase("CatalogServiceDb");

var cartServiceApi = builder.AddProject<Projects.OnlineShopping_CartService_WebApi>("CartServiceApi")
    .WithReference(rabbitmq);

var catalogServiceApi = builder.AddProject<Projects.OnlineShopping_CatalogService_WebApi>("CatalogServiceApi")
    .WithReference(sqlServer);

builder.Build().Run();
 