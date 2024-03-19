﻿using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}
