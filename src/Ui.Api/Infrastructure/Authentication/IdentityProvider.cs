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
        return GetAuthenticatedUser().Id;
    }

    public AuthenticatedUser GetAuthenticatedUser()
    {
        var user = userRepository.FindById(GetIdFromContext());

        if (user is null)
        {
            throw new UnauthorizedException();
        }

        return new AuthenticatedUser(user.Id, user.Email.Value);
    }

    private Guid GetIdFromContext()
    {
        var id = context.GetClaim(JwtProvider.IdentityClaim);
        
        if (
            id is null 
            || !Guid.TryParse(id, out Guid guid))
        {
            throw new UnauthorizedException();
        }

        return guid;
    }
}
