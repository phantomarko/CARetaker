using Application.Abstractions.Authentication;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ui.Api.Infrastructure.Authentication;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        // endpoints
        services.AddEndpointsApiExplorer();
        services.AddFastEndpoints();
        services.SwaggerDocument();

        // authentication
        services.ConfigureOptions<JwtOptionsSetup>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddAuthenticationJwtBearer(s => { }, options =>
        {
            var jwtOptions = configuration.GetSection(JwtOptions.Section).Get<JwtOptions>()!;
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
            };
        });
        services.AddScoped<IIdentityProvider, HttpContextIdentityProvider>();

        // authorization
        services.ConfigureOptions<AuthorizationOptionsSetup>();
        services.AddAuthorization();

        return services;
    }
}
