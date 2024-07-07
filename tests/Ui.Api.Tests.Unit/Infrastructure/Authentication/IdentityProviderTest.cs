using Domain.Tests.Fixtures;
using Domain.Users;
using Moq;
using SharedKernel.Exceptions;
using Ui.Api.Infrastructure.Authentication;

namespace Ui.Api.Tests.Unit.Infrastructure.Authentication;

public class IdentityProviderTest
{
    private readonly Guid _userId;
    private readonly Mock<IContext> _context;
    private readonly Mock<IUserRepository> _repository;
    private readonly IdentityProvider _identityProvider;

    public IdentityProviderTest()
    {
        _userId = Guid.NewGuid();
        _context = new Mock<IContext>();
        _repository = new Mock<IUserRepository>();
        _identityProvider = new IdentityProvider(
            _context.Object,
            _repository.Object);
    }

    [Fact]
    public void GetAuthenticatedUserId_Should_ThrowException_WhenContextReturnNullIdentity()
    {
        Assert.Throws<UnauthorizedException>(() => _identityProvider.GetAuthenticatedUserId());

        _context.Verify(
            mock => mock.GetClaim(It.IsAny<string>()),
            Times.Once());
        _repository.Verify(
            mock => mock.FindById(It.IsAny<Guid>()),
            Times.Never());
    }

    [Fact]
    public void GetAuthenticatedUserId_Should_ThrowException_WhenIdentityClaimIsNotAGuid()
    {
        _context.Setup(mock => mock.GetClaim(JwtProvider.IdentityClaim))
            .Returns("not a GUID");

        Assert.Throws<UnauthorizedException>(() => _identityProvider.GetAuthenticatedUserId());

        _repository.Verify(
            mock => mock.FindById(It.IsAny<Guid>()),
            Times.Never());
    }

    [Fact]
    public void GetAuthenticatedUserId_Should_ThrowException_WhenUserNotExists()
    {
        _context.Setup(mock => mock.GetClaim(JwtProvider.IdentityClaim))
            .Returns(_userId.ToString());

        Assert.Throws<UnauthorizedException>(() => _identityProvider.GetAuthenticatedUserId());

        _repository.Verify(mock => mock.FindById(_userId), Times.Once());
    }

    [Fact]
    public void GetAuthenticatedUserId_Should_ReturnGuid()
    {
        _context.Setup(mock => mock.GetClaim(JwtProvider.IdentityClaim))
            .Returns(_userId.ToString());
        _repository.Setup(mock => mock.FindById(_userId))
            .Returns(UsersMother.MakeUser(id: _userId));

        var userId = _identityProvider.GetAuthenticatedUserId();

        Assert.Equal(_userId, userId);
    }
}
