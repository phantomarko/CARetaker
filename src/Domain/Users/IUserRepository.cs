namespace Domain.Users;

public interface IUserRepository
{
    Task AddAsync(
        User user,
        CancellationToken cancellationToken = default);

    User? FindById(Guid id);

    User? FindByEmail(Email email);
}
