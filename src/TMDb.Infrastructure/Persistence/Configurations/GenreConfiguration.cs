using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMDb.Domain.Entities;

namespace TMDb.Infrastructure.Persistence.Configurations;

[ExcludeFromCodeCoverage]
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder
            .Property(x => x.GenreType)
            .IsRequired();
    }
}
