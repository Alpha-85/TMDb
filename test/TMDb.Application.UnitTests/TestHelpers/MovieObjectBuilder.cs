using TMDb.Application.Common.Models.MovieModels;
using TMDb.Application.Common.Models.RequestModels;
using TMDb.Domain.Common.Enums;
using TMDb.Domain.Entities;

namespace TMDb.Application.UnitTests.TestHelpers;

public static class MovieObjectBuilder
{
    public static MovieModel GetMovieModel()
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

    public static Movie GetMovie()
    {
        var movie = new Movie
        {
            Created = DateTime.MinValue,
            LastModified = DateTime.MinValue,
            Id = 1,
            Title = "Conan the barbarian",
            Year = 1982,
            Synopsis =
                "A young boy, Conan, becomes a slave after his parents are killed and tribe destroyed by a savage warlord and sorcerer, Thulsa Doom.",
            Director = "John Milius",
            Genres = new List<Genre>
            {
                new()
                {
                    Created = DateTime.MinValue,
                    LastModified = DateTime.MinValue,
                    Id = 1,
                    MovieId = 1,
                    Movie = null,
                    GenreType = GenreType.Action
                }
            },
            Actors = new List<Actor>()
        };

        return movie;
    }
}
