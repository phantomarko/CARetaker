using System.Security.Cryptography;
using System.Text;

namespace Domain.Users;

public sealed class PasswordHasher(string pepper, int iterations)
{
    public string Compute(string plainPassword, string salt)
    {
        return ComputeWithCondiments(
            plainPassword,
            salt,
            pepper,
            iterations);
    }

    private string ComputeWithCondiments(
        string password,
        string salt,
        string pepper,
        int iteration)
    {
        if (iteration <= 0)
        {
            return password;
        }

        using var sha256 = SHA256.Create();
        var passwordSaltPepper = $"{password}{salt}{pepper}";
        var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
        var byteHash = sha256.ComputeHash(byteValue);
        var hash = Convert.ToBase64String(byteHash);

        return ComputeWithCondiments(hash, salt, pepper, iteration - 1);
    }
}
