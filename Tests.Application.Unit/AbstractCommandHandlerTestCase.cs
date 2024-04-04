using Application.Abstractions;
using Moq;

namespace Tests.Application.Unit;

public abstract class AbstractCommandHandlerTestCase
{
    protected readonly Mock<IIdentityProvider> _identityProvider;

    protected AbstractCommandHandlerTestCase()
    {
        _identityProvider = new Mock<IIdentityProvider>();
    }

    protected void UserIsAuthenticated()
    {
        _identityProvider.Setup(mock => mock.GetAuthenticatedUserId()).Returns(Guid.NewGuid());
    }
}
