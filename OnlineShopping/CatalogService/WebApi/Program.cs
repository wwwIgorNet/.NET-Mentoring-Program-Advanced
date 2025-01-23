using Microsoft.EntityFrameworkCore;
using OnlineShopping.CatalogService.Application;
using OnlineShopping.CatalogService.Infrastructure;
using OnlineShopping.CatalogService.Infrastructure.Data;
using OnlineShopping.CatalogService.WebApi;
using OnlineShopping.CatalogService.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();

builder.Services.AddApplicationServices();
builder.AddSqlServerDbContext<ApplicationDbContext>("CatalogServiceDb");
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.UseSwaggerGenWithAuth(builder.Configuration);

builder.Services.UseAuthorization();
builder.Services.UseAuthentication(builder.Configuration);

builder.Services.AddAuthorizationBuilder();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.OAuthClientId(builder.Configuration["Keycloak:ClientID"]);
    });
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
