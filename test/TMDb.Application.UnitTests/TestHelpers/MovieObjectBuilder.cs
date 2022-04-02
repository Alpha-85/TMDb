using TMDb.Application.Common.Models.MovieModels;
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

    public static List<Movie> GetListOfThreeMovies()
    {
        var movies = new List<Movie>();

        var movieOne = new Movie
        {
            Created = DateTime.MinValue,
            LastModified = DateTime.MinValue,
            Id = 1,
            Title = "Conan the barbarian",
            Year = 1982,
            Synopsis = "A text that describes the content",
            Director = "John Milius",
            Genres = new List<Genre>(),
            Actors = new List<Actor>()
        };

        var movieTwo = new Movie
        {
            Created = DateTime.MinValue,
            LastModified = DateTime.MinValue,
            Id = 2,
            Title = "Jaws",
            Year = 1975,
            Synopsis = "A text that describes the content",
            Director = "Stephen Spielberg",
            Genres = new List<Genre>(),
            Actors = new List<Actor>()
        };

        var movieThree = new Movie
        {
            Created = DateTime.MinValue,
            LastModified = DateTime.MinValue,
            Id = 3,
            Title = "Robocop",
            Year = 1987,
            Synopsis = "A text that describes the content",
            Director = "Paul Verhoeven",
            Genres = new List<Genre>(),
            Actors = new List<Actor>()
        };

        movies.Add(movieOne);
        movies.Add(movieTwo);
        movies.Add(movieThree);

        return movies;
    }
}
