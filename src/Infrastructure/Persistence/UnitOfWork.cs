﻿using Application.Abstractions.Data;

namespace Infrastructure.Persistence;

public sealed class UnitOfWork(ApplicationDbContext context)
    : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
