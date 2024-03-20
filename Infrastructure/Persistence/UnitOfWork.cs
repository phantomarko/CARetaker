using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UnitOfWork(ApplicationContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync();
    }
}
