using TMDb.Domain.Common;

namespace TMDb.Domain.Entities;

public class Movie : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Synopsis { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public List<Genre> GenresList { get; set; } = new();
    public List<Actor> ActorList { get; set; } = new();

}
