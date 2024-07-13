using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Users.Responses;

namespace Application.Users.Queries.GetAuthenticatedUser;

public sealed class GetAuthenticatedUserQueryHandler(
    IIdentityProvider identityProvider)
    : IQueryHandler<GetAuthenticatedUserQuery, UserResponse>
{
    public Task<UserResponse> Handle(
        GetAuthenticatedUserQuery request,
        CancellationToken cancellationToken = default)
    {
        var authenticatedUser = identityProvider.GetAuthenticatedUser();

        return Task.FromResult(new UserResponse(
            authenticatedUser.Id.ToString(),
            authenticatedUser.Email));
    }
}
