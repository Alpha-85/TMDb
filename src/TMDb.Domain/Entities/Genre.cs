using TMDb.Domain.Common;
using TMDb.Domain.Common.Enums;

namespace TMDb.Domain.Entities;

public class Genre : AuditableEntity
{
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public GenreType GenreType { get; set; }
}
