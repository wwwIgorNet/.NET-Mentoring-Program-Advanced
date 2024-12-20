using Microsoft.OpenApi.Models;

namespace OnlineShopping.CartService.WebApi.UI.Configurations;

internal static class SwaggerGenServiceCollectionExtensions
{
    internal static IServiceCollection UseSwagger(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                "v1", 
                new OpenApiInfo 
                { 
                    Title = "Carts API - V1", 
                    Version = "v1"
                });

            options.SwaggerDoc(
                "v2",
                new OpenApiInfo 
                { 
                    Title = "Carts API - V2", 
                    Version = "v2"
                });

            options.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(configuration["Keycloak:AuthorizationUrl"]!),
                        Scopes = new Dictionary<string, string>
                    {
                        { "openid", "openid" },
                        { "profile", "profile" }
                    }
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Keycloak",
                        Type = ReferenceType.SecurityScheme,
                    },
                    In = ParameterLocation.Header,
                    Name = "Bearer",
                    Scheme = "Bearer",
                },
                Array.Empty<string>()
            },
        });
        });

        return services;
    }
}
