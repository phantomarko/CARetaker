using Application.Abstractions;
using Application.Exceptions;

namespace Application.Primitives;

public abstract class AuthenticatedHandler(IIdentityProvider identityProvider)
{
    protected Guid AuthenticatedUserId =>
        identityProvider.GetAuthenticatedUserId() ?? throw new AuthorizationNeededException();
}
