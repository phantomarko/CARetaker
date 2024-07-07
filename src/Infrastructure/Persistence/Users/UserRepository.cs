using Domain.Users;

namespace Infrastructure.Persistence.Users;

public sealed class UserRepository(ApplicationDbContext context)
    : IUserRepository
{
    public async Task AddAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }

    public User? FindById(Guid id)
    {
        return context.Users.FirstOrDefault(user => user.Id == id);
    }

    public User? FindByEmail(Email email)
    {
        return context.Users.FirstOrDefault(user => user.Email == email);
    }
}
