using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using OnlineShopping.CartService.WebApi;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carts API - V1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Carts API - V2", Version = "v2" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
        c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
