namespace Ui.Api.Infrastructure.Authentication;

public sealed class JwtOptions
{
    public const string Section = "Jwt";

    public string Issuer { get; init; } = string.Empty;

    public string Audience { get; init; } = string.Empty;

    public string SecretKey { get; init; } = string.Empty;

    public int LifetimeInHours { get; init; }
}
