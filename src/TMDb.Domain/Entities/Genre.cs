using TMDb.Domain.Common;
using TMDb.Domain.Common.Enums;

namespace TMDb.Domain.Entities;

public class Genre : AuditableEntity
{
    public GenreType GenreType { get; set; }
}
