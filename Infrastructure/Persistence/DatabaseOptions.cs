namespace Infrastructure.Persistence;

public class DatabaseOptions
{
    public const string Section = "Database";

    public string Server { get; init; } = string.Empty;

    public int Port { get; init; }

    public string Name { get; init; } = string.Empty;

    public string User { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public bool DetailedErrors { get; init; }

    public bool SensitiveDataLogging { get; init; }
}
