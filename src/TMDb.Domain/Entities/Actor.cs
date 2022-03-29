using TMDb.Domain.Common;

namespace TMDb.Domain.Entities;

public class Actor : AuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
