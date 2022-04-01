using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using TMDb.Application.Movies.Commands;
using TMDb.Application.UnitTests.TestHelpers;
using Xunit;

namespace TMDb.Application.UnitTests.Handlers;

public class MovieCommandHandlerTests
{
    [Fact]
    public async Task AddMovieHandler_Should_AddNewMovie()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();

        var logger = Substitute.For<ILogger<AddMovieCommandHandler>>();
        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new AddMovieCommand(MovieObjectBuilder.GetMovieModel());
        var sut = new AddMovieCommandHandler(applicationDbContext, logger, mapper);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        await applicationDbContext.Received(1).SaveChangesAsync(CancellationToken.None);
        result.Should().NotBeNull();

    }

    [Fact]
    public async Task AddMovieHandler_Should_ReturnFaultedMessage()
    {
        // Arrange
        var applicationDbContext = DbContextHelper.GetApplicationDbContext();

        applicationDbContext
            .When(x => x.SaveChangesAsync(CancellationToken.None))
            .Throw(new Exception());

        var logger = Substitute.For<ILogger<AddMovieCommandHandler>>();
        var mapper = AutoMapperHelper.GetAutoMapper();
        var request = new AddMovieCommand(MovieObjectBuilder.GetMovieModel());
        var sut = new AddMovieCommandHandler(applicationDbContext, logger, mapper);

        // Act
        await sut.Handle(request, CancellationToken.None);

        // Assert
        logger.ReceivedWithAnyArgs().LogError("Database Error: Failed to insert {request.Movie}", request.Movie);

    }

}
