using Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ui.Api.Infrastructure.Authentication;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        // controllers
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // authentication
        services.ConfigureOptions<JwtOptionsSetup>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
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
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddHttpContextAccessor();
        services.AddScoped<IIdentityProvider, HttpContextIdentityProvider>();

        // authorization
        services.ConfigureOptions<AuthorizationOptionsSetup>();
        services.AddAuthorization();

        return services;
    }
}
