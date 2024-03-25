using Infrastructure.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ui.Api;

public class JwtBearerOptionsSetup(IOptions<JwtOptions> options) : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))
        };
    }
}
