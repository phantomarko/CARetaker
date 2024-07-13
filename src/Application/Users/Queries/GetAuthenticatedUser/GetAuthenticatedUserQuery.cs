using Application.Abstractions.Messaging;
using Application.Users.Responses;

namespace Application.Users.Queries.GetAuthenticatedUser;

public sealed record GetAuthenticatedUserQuery : IQuery<UserResponse>;
