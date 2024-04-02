namespace Infrastructure.Security.PasswordHasher;

public class PasswordHasherOptions
{
    public const string Section = "PasswordHasher";

    public string Pepper { get; init; } = string.Empty;

    public int Iterations { get; init; }
}
