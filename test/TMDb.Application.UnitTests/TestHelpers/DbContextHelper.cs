using EntityFrameworkCore.Testing.NSubstitute;
using Microsoft.EntityFrameworkCore;
using TMDb.Infrastructure.Persistence;

namespace TMDb.Application.UnitTests.TestHelpers;

public static class DbContextHelper
{

    public static ApplicationDbContext GetApplicationDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        var applicationDbContext = Create.MockedDbContextFor<ApplicationDbContext>(options);

        return applicationDbContext;
    }
}