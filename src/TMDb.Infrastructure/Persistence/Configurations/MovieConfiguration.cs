using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence.Configurations;

[ExcludeFromCodeCoverage]
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .HasMany(x => x.Actors)
            .WithOne(x => x.Movie)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Genres)
            .WithOne(x => x.Movie)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.Director)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Synopsis)
            .HasMaxLength(200);

        builder
            .Property(x => x.Year)
            .IsRequired();

        builder
            .Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();

    }
}
