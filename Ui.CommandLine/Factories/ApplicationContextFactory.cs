using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ui.CommandLine.Factories;

internal class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=caretaker;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;");

        return new ApplicationContext(optionsBuilder.Options);
    }
}
