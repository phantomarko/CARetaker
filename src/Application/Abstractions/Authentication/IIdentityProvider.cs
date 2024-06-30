namespace Application.Abstractions.Authentication;

public interface IIdentityProvider
{
    Guid GetAuthenticatedUserId();
}
