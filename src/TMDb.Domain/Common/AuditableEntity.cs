namespace TMDb.Domain.Common;

public abstract class AuditableEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
    