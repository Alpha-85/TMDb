using TMDb.Domain.Common;

namespace TMDb.Domain.Entities;

public class Actor : AuditableEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
