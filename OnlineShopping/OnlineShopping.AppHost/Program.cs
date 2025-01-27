var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQUserName = builder.AddParameter("RabbitMQUser", secret: true);
var rabbitMQPassword = builder.AddParameter("RabbitMQPassword", secret: true);
var rabbitmq = builder.AddRabbitMQ(name: "messaging", userName: rabbitMQUserName, password: rabbitMQPassword)
    .WithDataVolume(name: "data-rabbitMQ", isReadOnly: false)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithManagementPlugin();

var sqlPassword = builder.AddParameter("MSSQLServerPassord", secret: true);
var sqlServer = builder.AddSqlServer(name: "mssql", password: sqlPassword, port: 53531)
    .WithDataVolume(name: "data-mssql", isReadOnly: false)
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("CatalogServiceDb");

var keycloakUser = builder.AddParameter("KeycloakUser");
var keycloakPassword = builder.AddParameter("KeycloakPassword", secret: true);
var keycloak = builder.AddKeycloak("keycloak", 8080, keycloakUser, keycloakPassword)
    .WithDataVolume(name: "data-keycloak")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithExternalHttpEndpoints();

var cartServiceApi = builder.AddProject<Projects.OnlineShopping_CartService_WebApi>("CartServiceApi")
    .WithReference(rabbitmq)
    .WaitFor(rabbitmq)
    .WithReference(keycloak)
    .WaitFor(keycloak);

var catalogServiceApi = builder.AddProject<Projects.OnlineShopping_CatalogService_WebApi>("CatalogServiceApi")
    .WithReference(sqlServer)
    .WaitFor(sqlServer)
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.AddAzureFunctionsProject<Projects.OnlineShopping_CatalogService_OutboxProcessing>("OutboxProcessing")
    .WithReference(sqlServer)
    .WithReference(rabbitmq)
    .WaitFor(rabbitmq)
    .WaitFor(sqlServer);

await builder.Build().RunAsync();
 