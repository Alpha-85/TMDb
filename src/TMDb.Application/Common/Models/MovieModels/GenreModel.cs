using System.Text.Json.Serialization;
using TMDb.Domain.Common.Enums;

namespace TMDb.Application.Common.Models.MovieModels;

public class GenreModel
{
    [JsonPropertyName("genre")]
    public GenreType GenreType { get; set; }

}
