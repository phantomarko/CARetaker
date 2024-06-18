namespace Application.Abstractions;

public interface IIdentityProvider
{
    Guid GetAuthenticatedUserId();
}
