using MediatR;

namespace Application.Users.Commands.LoginUser;

public sealed record LoginUserCommand(string Email, string Password) 
    : IRequest<string>;
