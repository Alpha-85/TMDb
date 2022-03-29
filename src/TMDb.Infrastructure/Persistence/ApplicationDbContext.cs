using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TMDb.Application.Common.Interfaces;
using TMDb.Domain.Common;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(DbContextOptions options, IDateTime dateTime) : base(options)
    {
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
    }

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Actor>? Actors { get; set; }
    public DbSet<Genre>? Genres { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.Now;
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
