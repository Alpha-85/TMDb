using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TMDb.Application.Movies.Commands;
using TMDb.Application.UnitTests.TestHelpers;
using TMDb.WebApi.Controllers;
using Xunit;


namespace TMDb.Application.UnitTests.Controllers;

public class MemberControllerTests
{

    [Fact]
    public async Task MovieController_Should_Return_StatusCode201()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var sut = new MovieController(mediator);
        var request = RequestObjectBuilder.GetMovieRequestModel();

        mediator.Send(Arg.Any<AddMovieCommand>()).Returns(1);

        // Act
        var result = await sut.CreateAsync(request, CancellationToken.None);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();

    }

    [Fact]
    public async Task MovieController_Should_Return_StatusCode400()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        var sut = new MovieController(mediator);
        var request = RequestObjectBuilder.GetMovieRequestModel();
        mediator.Send(Arg.Any<AddMovieCommand>())
            .Returns(i => Task.FromResult<int?>(null));

        // Act
        var result = await sut.CreateAsync(request, CancellationToken.None);

        // Assert
        result.Should().BeOfType<BadRequestResult>();

    }

}


