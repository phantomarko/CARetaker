﻿namespace Infrastructure.Security.Jwt;

public class JwtOptions
{
    public string Issuer { get; init; } = string.Empty;

    public string Audience { get; init; } = string.Empty;

    public string SecretKey { get; init; } = string.Empty;

    public int LifetimeInHours { get; init; }
}
