using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TMDb.Application.Common.Interfaces;
using TMDb.Domain.Common;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.Now;
                    break;

            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
