using System.Text.Json.Serialization;

namespace TMDb.Application.Common.Models.MovieModels;

public class ActorModel
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;
    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;
}
