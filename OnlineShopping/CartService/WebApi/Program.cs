using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using OnlineShopping.CartService.WebApi;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.DAL;
using OnlineShopping.CartService.WebApi.UI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.AddRabbitMQClient(connectionName: "messaging");
builder.Services.AddHostedService<OutboxMessegesConsumerJob>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILiteDbContext, LiteDbContext>();
builder.Services.AddTransient<ICartItemsRepository, CartItemsRepository>();
builder.Services.AddTransient<ICartItemsService, CartItemsService>();
builder.Services.Configure<LiteDbOptions>(options => builder.Configuration.GetSection(nameof(LiteDbOptions)).Bind(options));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader =
    ApiVersionReader.Combine(
       new HeaderApiVersionReader("X-Api-Version"),
       new UrlSegmentApiVersionReader());

    options.UseApiBehavior = false;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.UseSwagger(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
        options.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
        options.OAuthClientId(builder.Configuration["Keycloak:ClientID"]);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
