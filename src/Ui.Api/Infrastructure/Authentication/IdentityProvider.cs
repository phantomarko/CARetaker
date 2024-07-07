using Application.Abstractions.Authentication;
using Domain.Users;
using SharedKernel.Exceptions;

namespace Ui.Api.Infrastructure.Authentication;

public sealed class IdentityProvider(
    IContext context,
    IUserRepository userRepository)
    : IIdentityProvider
{
    public Guid GetAuthenticatedUserId()
    {
        var userId = GetIdentityClaimFromContext();

        if (
            userId is null
            || !UserExists((Guid)userId))
        {
            throw new UnauthorizedException();
        }

        return (Guid)userId;
    }

    private Guid? GetIdentityClaimFromContext()
    {
        var id = context.GetClaim(JwtProvider.IdentityClaim);
        
        if (
            id is null 
            || !Guid.TryParse(id, out Guid guid))
        {
            return null;
        }

        return guid;
    }

    private bool UserExists(Guid id)
    {
        var user = userRepository.FindById(id);

        return user is not null;
    }
}
