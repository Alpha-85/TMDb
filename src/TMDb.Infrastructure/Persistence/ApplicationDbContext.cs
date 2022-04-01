using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TMDb.Application.Common.Interfaces;
using TMDb.Domain.Common;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public virtual DbSet<Movie> Movies { get; set; } = null!;
    public virtual DbSet<Actor> Actors { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;

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
