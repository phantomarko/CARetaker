namespace Application.Abstractions.Authentication;

public sealed record AuthenticatedUser(Guid Id, string Email);
