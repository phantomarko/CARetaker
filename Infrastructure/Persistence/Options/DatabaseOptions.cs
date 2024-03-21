namespace Infrastructure.Persistence.Options;

public class DatabaseOptions
{
    public string Server { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Name { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Encrypt { get; set; }
    public bool DetailedErrors { get; set; }
    public bool SensitiveDataLogging { get; set; }
}
