using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using TMDb.Application.Movies.Commands;
using TMDb.Application.UnitTests.TestHelpers;
using Xunit;

namespace TMDb.Application.UnitTests.Handlers;

public class DeleteMovieCommandHandlerTests
{
    [Fact]
    public async Task DeleteMovieHandler_Should_DeleteMovie()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var movie = MovieObjectBuilder.GetMovie();
        applicationDbContext.Movies.Add(movie);
        await applicationDbContext.SaveChangesAsync();
        var logger = Substitute.For<ILogger<DeleteMovieCommandHandler>>();
        var request = new DeleteMovieCommand(1);
        var sut = new DeleteMovieCommandHandler(applicationDbContext, logger);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        await applicationDbContext.Received().SaveChangesAsync(CancellationToken.None);
        result.Should().Be(true);

    }

    [Fact]
    public async Task DeleteMovieHandler_Should_Return_False_When_Movie_Is_Not_Found()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var logger = Substitute.For<ILogger<DeleteMovieCommandHandler>>();
        var request = new DeleteMovieCommand(1);
        var sut = new DeleteMovieCommandHandler(applicationDbContext, logger);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().Be(false);

    }

    [Fact]
    public async Task DeleteMovieHandler_Should_ReturnFaultedMessage()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();
        var movie = MovieObjectBuilder.GetMovie();
        applicationDbContext.Movies.Add(movie);
        await applicationDbContext.SaveChangesAsync();
        var logger = Substitute.For<ILogger<DeleteMovieCommandHandler>>();
        var request = new DeleteMovieCommand(1);
        applicationDbContext
            .When(x => x.SaveChangesAsync(CancellationToken.None))
            .Throw(new Exception());
        var sut = new DeleteMovieCommandHandler(applicationDbContext, logger);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        logger.ReceivedWithAnyArgs().LogError("Failed to Remove Entity from database with id: {request.MovieId}", request.MovieId);
        result.Should().BeFalse();
    }
}
