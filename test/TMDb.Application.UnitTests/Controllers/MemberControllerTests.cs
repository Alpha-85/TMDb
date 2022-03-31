using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TMDb.Application.Movies.Commands;
using TMDb.Application.Movies.Queries;
using TMDb.Application.UnitTests.TestHelpers;
using TMDb.WebApi.Controllers;
using Xunit;


namespace TMDb.Application.UnitTests.Controllers;

public class MemberControllerTests
{

    [Fact]
    public async Task MovieController_Post_Should_Return_StatusCode201()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var sut = new MovieController(mediator);
        var request = MovieObjectBuilder.GetMovieModel();

        mediator.Send(Arg.Any<AddMovieCommand>()).Returns(1);

        // Act
        var result = await sut.CreateAsync(request, CancellationToken.None);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();

    }

    [Fact]
    public async Task MovieController_Post_Should_Return_StatusCode400()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var sut = new MovieController(mediator);
        var request = MovieObjectBuilder.GetMovieModel();
        mediator.Send(Arg.Any<AddMovieCommand>())
            .Returns(i => Task.FromResult<int?>(null));

        // Act
        var result = await sut.CreateAsync(request, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BadRequestResult>();

    }

    [Fact]
    public async Task MovieController_Get_Should_Return_StatusCode200()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var sut = new MovieController(mediator);
        mediator.Send(Arg.Any<GetMovieQuery>())
            .Returns(MovieObjectBuilder.GetMovieModel());

        // Act
        var result = await sut.GetAsync(1, CancellationToken.None);

        // Assert
        result.Should().BeOfType<OkObjectResult>();

    }

    [Fact]
    public async Task MovieController_Get_Should_Return_StatusCode404()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var sut = new MovieController(mediator);
        mediator.Send(Arg.Any<GetMovieQuery>())
            .ReturnsNull();

        // Act
        var result = await sut.GetAsync(1, CancellationToken.None);

        // Assert
        result.Should().BeOfType<NotFoundResult>();

    }

}


