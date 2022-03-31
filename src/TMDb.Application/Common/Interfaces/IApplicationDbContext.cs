using Microsoft.EntityFrameworkCore;
using TMDb.Domain.Entities;

namespace TMDb.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    DbSet<Actor> Actors { get; }
    DbSet<Genre> Genres { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
