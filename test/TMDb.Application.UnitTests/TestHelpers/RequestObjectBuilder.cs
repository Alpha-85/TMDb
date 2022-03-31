using TMDb.Application.Common.Models.MovieModels;
using TMDb.Application.Common.Models.RequestModels;
using TMDb.Domain.Common.Enums;

namespace TMDb.Application.UnitTests.TestHelpers;

public static class RequestObjectBuilder
{
    public static MovieModel GetMovieRequestModel()
    {
        var request = new MovieModel
        {
            Title = "Conan the barbarian",
            Year = 1982,
            Synopsis = "A young boy, Conan, becomes a slave after his parents are killed and tribe destroyed by a savage warlord and sorcerer, Thulsa Doom.",
            Director = "John Milius",
            Genres = new List<GenreModel>
            {
                new()
                {
                    GenreType = GenreType.Action
                }
            },

            Actors = new List<ActorModel>
            {
                new()
                {
                    FirstName = "Arnold",
                    LastName = "Schwarzenegger"
                }
            }
        };

        return request;
    }
}
