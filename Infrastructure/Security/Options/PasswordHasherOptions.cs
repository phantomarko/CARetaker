namespace Infrastructure.Security.Options;

public class PasswordHasherOptions
{
    public string Pepper { get; set; } = String.Empty;

    public int Iterations { get; set; }
}
