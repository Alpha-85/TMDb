using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TMDb.Application.Common.Interfaces;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Actor>? Actors { get; set; }
    public DbSet<Genre>? Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
