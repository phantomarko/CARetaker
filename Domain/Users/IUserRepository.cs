namespace Domain.Users;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    Task<User?> FindByEmailAsync(Email email, CancellationToken cancellationToken = default);

    User? FindByEmail(Email email);
}
