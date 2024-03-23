using Domain.Primitives;
using System.Security.Cryptography;

namespace Domain.Users;

public sealed class User : Entity
{
    private User(
        Guid id,
        Email email,
        string passwordSalt,
        string passwordHash) : base(id)
    {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
    }

    public Email Email { get; init; }

    private string PasswordSalt { get; init; }

    private string PasswordHash { get; init; }

    public bool PasswordMatches(
        string plainPassword,
        PasswordHasher passwordHasher)
    {
        var passwordHash = passwordHasher.Compute(plainPassword, PasswordSalt);

        return passwordHash == PasswordHash;
    }

    public static User Create(
        Guid id,
        Email email,
        Password password,
        PasswordHasher passwordHasher)
    {
        var passwordSalt = GenerateSalt();
        var passwordHash = passwordHasher.Compute(password.Value, passwordSalt);
        return new User(
            id,
            email,
            passwordSalt,
            passwordHash);
    }

    private static string GenerateSalt()
    {
        using var rng = RandomNumberGenerator.Create();
        var byteSalt = new byte[16];
        rng.GetBytes(byteSalt);
        var salt = Convert.ToBase64String(byteSalt);
        return salt;
    }
}
