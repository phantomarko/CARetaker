namespace Ui.Api.Users.Endpoints.CreateUser;

public sealed record CreateUserRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}
