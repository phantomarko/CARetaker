namespace Ui.Api.Infrastructure.Authentication;

public interface IContext
{
    string? GetClaim(string name);
}
