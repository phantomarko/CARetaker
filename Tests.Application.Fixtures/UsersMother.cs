using Application.Users.Commands.AuthorizeUser;
using Application.Users.Commands.CreateUser;

namespace Tests.Application.Fixtures;

public class UsersMother
{
    private const string EmailDefault = "user@domain.example";
    private const string PasswordDefault = "P4ssw0rd";

    public static CreateUserCommand MakeCreateUserCommand(
        string? email = null,
        string? password = null)
    {
        return new CreateUserCommand(
            email ?? EmailDefault,
            password ?? PasswordDefault);
    }

    public static AuthorizeUserCommand MakeAuthorizeUserCommand(
        string? email = null,
        string? password = null)
    {
        return new AuthorizeUserCommand(
            email ?? EmailDefault,
            password ?? PasswordDefault);
    }
}
