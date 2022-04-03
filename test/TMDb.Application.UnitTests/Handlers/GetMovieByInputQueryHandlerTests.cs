using FluentAssertions;
using TMDb.Application.Common.Models;
using TMDb.Application.Common.Models.MovieModels;
using TMDb.Application.Movies.Queries;
using TMDb.Application.UnitTests.TestHelpers;
using Xunit;

namespace TMDb.Application.UnitTests.Handlers;

public class GetMovieByInputQueryHandlerTests
{
    [Fact]
    public async Task GetMovieByInputQueryHandler_Should_Return_PaginationResult()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new GetMovieByInputQuery(1, 10, "test");
        var sut = new GetMovieByInputQueryHandler(applicationDbContext, mapper);
        // Act
        var result = await sut.Handle(request, CancellationToken.None);
        // Assert
        result.Should().BeOfType<PaginationResult<MovieModel>>();
    }

    [Fact]
    public async Task GetMovieByInputQueryHandler_Should_Return_Empty_PaginationResult()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new GetMovieByInputQuery(1, 10, "");
        var sut = new GetMovieByInputQueryHandler(applicationDbContext, mapper);
        // Act
        var result = await sut.Handle(request, CancellationToken.None);
        // Assert
        result.EnumerableQueryResult.Should().BeEmpty();
        result.NextPage.Should().Be(0);
        result.Should().BeOfType<PaginationResult<MovieModel>>();
    }

    [Theory]
    [MemberData(nameof(PaginationTestData))]
    public async Task GetMovieByInputQueryHandler_Should_Return_Correct_AmountOfMovies(string searchString, int expectedResult)
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var movies = MovieObjectBuilder.GetListOfThreeMovies();
        applicationDbContext.Movies.AddRange(movies);
        await applicationDbContext.SaveChangesAsync();

        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new GetMovieByInputQuery(0, 0, searchString);
        var sut = new GetMovieByInputQueryHandler(applicationDbContext, mapper);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.EnumerableQueryResult.Should().HaveCount(expectedResult);
        result.TotalCount.Should().Be(expectedResult);
    }

    private static List<object[]> PaginationTestData()
    {
        return new List<object[]>
        {
            new object[] { "test", 0 },
            new object[] { "Conan", 1 },
            new object[] {  "o", 2 },
        };
    }
}
