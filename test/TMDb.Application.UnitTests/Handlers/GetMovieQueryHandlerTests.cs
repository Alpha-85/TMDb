using FluentAssertions;
using TMDb.Application.Common.Models.MovieModels;
using TMDb.Application.Movies.Queries;
using TMDb.Application.UnitTests.TestHelpers;
using Xunit;

namespace TMDb.Application.UnitTests.Handlers;

public class GetMovieQueryHandlerTests
{
    [Fact]
    public async Task GetMovieQueryHandler_Should_Return_MovieModel()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var movie = MovieObjectBuilder.GetMovie();
        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new GetMovieQuery(1);
        var sut = new GetMovieQueryHandler(applicationDbContext, mapper);

        // Act
        applicationDbContext.Movies.Add(movie);
        await applicationDbContext.SaveChangesAsync();
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<MovieModel>();

    }

    [Fact]
    public async Task GetMovieQueryHandler_Should_Return_Null()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new GetMovieQuery(1);
        var sut = new GetMovieQueryHandler(applicationDbContext, mapper);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().BeNull();

    }
}
