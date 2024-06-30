using Domain.Primitives;
using Domain.Users.Exceptions;
using System.Security.Cryptography;

namespace Domain.Users;

public sealed class User : AggregateRoot
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

    public Email Email { get; private set; }

    public string PasswordSalt { get; private set; }

    public string PasswordHash { get; private set; }

    public bool PasswordMatches(
        string plainPassword,
        PasswordHasher passwordHasher)
    {
        var passwordHash = passwordHasher.Compute(
            plainPassword,
            PasswordSalt);

        return passwordHash == PasswordHash;
    }

    public static User Create(
        Guid id,
        Email email,
        Password password,
        PasswordHasher passwordHasher,
        IUserRepository userRepository)
    {
        if (userRepository.FindByEmail(email) is not null)
        {
            throw new EmailIsAlreadyInUseException();
        }

        var passwordSalt = GenerateSalt();
        var passwordHash = passwordHasher.Compute(
            password.Value,
            passwordSalt);

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
