﻿using Application.Abstractions.Authentication;
using Moq;

namespace Application.Tests.Unit;

public abstract class AuthenticatedHandlerTestCase
{
    protected readonly Mock<IIdentityProvider> _identityProvider;
    protected readonly Guid _userId;

    protected AuthenticatedHandlerTestCase()
    {
        _identityProvider = new Mock<IIdentityProvider>();
        _userId = Guid.NewGuid();
    }

    protected void UserIsAuthenticated(Guid? userId = null)
    {
        _identityProvider.Setup(mock => mock.GetAuthenticatedUserId()).Returns(userId ?? _userId);
    }
}
