using Application.Abstractions;
using Moq;

namespace Tests.Application.Unit;

public abstract class AbstractCommandHandlerTestCase
{
    protected readonly Mock<IIdentityProvider> _identityProvider;
    protected readonly Guid _userId;

    protected AbstractCommandHandlerTestCase()
    {
        _identityProvider = new Mock<IIdentityProvider>();
        _userId = Guid.NewGuid();
    }

    protected void UserIsAuthenticated()
    {
        _identityProvider.Setup(mock => mock.GetAuthenticatedUserId()).Returns(_userId);
    }
}
