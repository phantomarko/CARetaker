namespace Infrastructure.Security.PasswordHasher;

public class PasswordHasherOptions
{
    public string Pepper { get; set; } = string.Empty;

    public int Iterations { get; set; }
}
