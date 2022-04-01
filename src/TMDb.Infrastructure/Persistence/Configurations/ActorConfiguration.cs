using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence.Configurations;

[ExcludeFromCodeCoverage]
public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder
            .Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();
    }
}
