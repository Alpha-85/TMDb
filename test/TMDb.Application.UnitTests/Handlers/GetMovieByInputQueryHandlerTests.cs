using FluentAssertions;
using TMDb.Application.Common.Models;
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
        result.Should().BeOfType<PaginationResult>();
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
        result.Movies.Should().BeEmpty();
        result.Should().BeOfType<PaginationResult>();
    }

    [Theory]
    [MemberData(nameof(PaginationTestData))]
    public async Task GetMovieByInputQueryHandler_Should_Return_Correct_AmountOfMovies(int next, int pageSize, string searchString, int expectedResult)
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var movies = MovieObjectBuilder.GetListOfThreeMovies();
        applicationDbContext.Movies.AddRange(movies);
        await applicationDbContext.SaveChangesAsync();

        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new GetMovieByInputQuery(next, pageSize, searchString);
        var sut = new GetMovieByInputQueryHandler(applicationDbContext, mapper);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.NextPage.Should().Be(next + 1);
        result.Movies.Should().HaveCount(expectedResult);

    }



    private static List<object[]> PaginationTestData()
    {
        return new List<object[]>
        {
            new object[] { 1, 0, "test", 0 },
            new object[] { 1, 10, "Conan", 1 },
            new object[] { 1, 1000, "o", 2 },
        };
    }

}
