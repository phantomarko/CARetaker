namespace Domain.Users;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);
}
