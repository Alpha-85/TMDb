using Microsoft.EntityFrameworkCore;
using TMDb.Infrastructure.Persistence;

namespace TMDb.Application.UnitTests.TestHelpers;

public static class DbContextHelper
{

    public static ApplicationDbContext GetApplicationDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        var applicationDbContext = new ApplicationDbContext(optionsBuilder.Options);

        return applicationDbContext;
    }
}