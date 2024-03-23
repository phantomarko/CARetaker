using Domain.Primitives;

namespace Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, Email email) : base(id)
    {
        Email = email;
    }

    public Email Email { get; init; }

    public static User Create(Guid id, Email email)
    {
        return new User(id, email);
    }
}
