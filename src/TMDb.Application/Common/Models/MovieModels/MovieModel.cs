using System.Text.Json.Serialization;

namespace TMDb.Application.Common.Models.MovieModels;

public class MovieModel
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("year")]
    public int? Year { get; set; }
    [JsonPropertyName("synopsis")]
    public string? Synopsis { get; set; }
    [JsonPropertyName("director")]
    public string? Director { get; set; }
    [JsonPropertyName("genres")]
    public List<GenreModel>? Genres { get; set; }
    [JsonPropertyName("actors")]
    public List<ActorModel>? Actors { get; set; }
}
