using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Users;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user);
    }

    public async Task<User?> FindByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        return await context.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
    }
}
