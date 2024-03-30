using Application.Abstractions;

namespace Application.Primitives;

public abstract class AuthenticatedHandler(IIdentityProvider identityProvider)
{
    protected Guid GetAuthenticatedUserId()
    {
        var userId = identityProvider.GetAuthenticatedUserId();

        if (userId is null)
        {
            throw new AuthorizationNeededException();
        }

        return (Guid)userId;
    }
}
