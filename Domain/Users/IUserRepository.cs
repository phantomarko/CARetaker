namespace Domain.Users;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);

    Task<User?> FindByEmailAsync(Email email, CancellationToken cancellationToken);
}
