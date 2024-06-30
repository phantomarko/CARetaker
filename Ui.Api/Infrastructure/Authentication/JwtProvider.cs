using Application.Abstractions.Authentication;
using Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ui.Api.Infrastructure.Authentication;

public sealed class JwtProvider(IOptions<JwtOptions> options)
    : IJwtProvider
{
    public const string IdentityClaim = "uuid";

    private readonly JwtOptions _jwtOptions = options.Value;

    public string Generate(User user)
    {
        var claims = new Claim[]
        {
            new (IdentityClaim, user.Id.ToString())
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(_jwtOptions.LifetimeInHours),
            signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
