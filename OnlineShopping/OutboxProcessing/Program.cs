using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using OnlineShopping.CatalogService.Infrastructure.Data;

var builder = FunctionsApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.ConfigureFunctionsWebApplication();

builder.AddSqlServerDbContext<ApplicationDbContext>("CatalogServiceDb");
builder.AddRabbitMQClient(connectionName: "messaging");

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

await builder.Build().RunAsync();
