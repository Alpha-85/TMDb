using System.Text.Json.Serialization;
using TMDb.Application.Common.Models.MovieModels;
using TMDb.Domain.Common.Enums;

namespace TMDb.Application.Common.Models.RequestModels;

public class MovieRequestModel
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [JsonPropertyName("synopsis")]
    public string Synopsis { get; set; }
    [JsonPropertyName("director")]
    public string Director { get; set; }
    [JsonPropertyName("genreType")]
    public GenreType GenreType { get; set; }
    [JsonPropertyName("actors")]
    public List<ActorModel> Actors { get; set; }
}
