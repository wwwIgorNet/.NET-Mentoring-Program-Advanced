﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.CatalogService.Domain.Constants;

namespace OnlineShopping.CatalogService.WebApi.Configurations;

public static class AuthenticationConfigurations
{
    public static IServiceCollection UseAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = Convert.ToBoolean($"{configuration["Authentication:RequireHttps"]}");
                x.Audience = configuration["Authentication:Audience"];
                x.MetadataAddress = configuration["Authentication:MetaDataAddress"]!;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"]
                };
            });

        return services;
    }

    public static IServiceCollection UseAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("email_verified", "true")
                .Build();
            options.AddPolicy(Policies.Read, policy => policy.RequireRole(Roles.Manager, Roles.StoreCustomer));
            options.AddPolicy(Policies.Edit, policy => policy.RequireRole(Roles.Manager));
            options.AddPolicy(Policies.Delete, policy => policy.RequireRole(Roles.Manager));
            options.AddPolicy(Policies.Create, policy => policy.RequireRole(Roles.Manager));
        });

        return services;
    }
}
