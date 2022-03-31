using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TMDb.Application.Common.Interfaces;
using TMDb.Infrastructure.Persistence;
using TMDb.Infrastructure.Services;

namespace TMDb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TMDb"));

        services.AddScoped<IApplicationDbContext>(provider => provider
            .GetService<ApplicationDbContext>() ?? throw new InvalidOperationException());

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}
