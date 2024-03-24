using Domain.Users;

namespace Infrastructure.Persistence.Users;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user);
    }
}
