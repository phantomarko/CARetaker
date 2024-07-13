using Application.Abstractions.Authentication;
using Application.Users.Queries.GetAuthenticatedUser;
using Moq;

namespace Application.Tests.Unit.Users.Queries.GetAuthenticatedUser;

public class GetAuthenticatedQueryHandlerTest
{
    private readonly Mock<IIdentityProvider> _identityProvider;
    private readonly GetAuthenticatedUserQueryHandler _handler;

    public GetAuthenticatedQueryHandlerTest()
    {
        _identityProvider = new Mock<IIdentityProvider>();
        _handler = new GetAuthenticatedUserQueryHandler(_identityProvider.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnUserResponse()
    {
        var authenticatedUser = new AuthenticatedUser(Guid.NewGuid(), "email@example.com");
        _identityProvider.Setup(mock => mock.GetAuthenticatedUser()).Returns(authenticatedUser);

        var response = await _handler.Handle(new GetAuthenticatedUserQuery());

        Assert.Equal(authenticatedUser.Id.ToString(), response.Id);
        Assert.Equal(authenticatedUser.Email, response.Email);
    }
}
