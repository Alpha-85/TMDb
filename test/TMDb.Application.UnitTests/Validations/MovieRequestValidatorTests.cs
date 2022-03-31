using FluentAssertions;
using FluentValidation.TestHelper;
using TMDb.Application.Common.Validators;
using TMDb.Application.UnitTests.TestHelpers;
using TMDb.Domain.Common.Enums;
using Xunit;

namespace TMDb.Application.UnitTests.Validations;

public class MovieRequestValidatorTests
{
    [Fact]
    public void MovieValidator_Should_Validate_Member()
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();

        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData("#!")]
    [InlineData("b")]
    [InlineData("")]
    [InlineData("Malty test string that ultimately should return in a false validation error Hopefully this works cause the text is long")]
    public void MovieValidator_ShouldHaveValidationErrorFor_Title(string title)
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();
        movieRequest.Title = title;

        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(movie => movie.Title);
    }

    [Theory]
    [InlineData("#!")]
    [InlineData("b")]
    [InlineData("")]
    [InlineData("Malty test string that ultimately should return in a false validation error Hopefully this works cause the text is long")]
    public void MovieValidator_ShouldHaveValidationErrorFor_Director(string director)
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();
        movieRequest.Director = director;

        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(movie => movie.Director);
    }

    [Theory]
    [InlineData("#!")]
    [InlineData("b")]
    [InlineData("")]
    [InlineData("Malty test string that taste with sweetness, hints of orange chocolate, breadcrumbs, espresso coffee, hazelnuts, vanilla and dark syrup that ultimately should return in a false validation error. Hopefully")]
    public void MovieValidator_ShouldHaveValidationErrorFor_Synopsis(string synopsis)
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();
        movieRequest.Synopsis = synopsis;

        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(movie => movie.Synopsis);
    }

    [Theory]
    [InlineData(1200)]
    [InlineData(null)]
    public void MovieValidator_ShouldHaveValidationErrorFor_Year(int? year)
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();
        movieRequest.Year = year;

        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(movie => movie.Year);
    }

    [Fact]
    public void MovieValidator_ShouldHaveValidationErrorFor_Genres()
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();
        movieRequest.Genres = null;

        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(movie => movie.Genres);
    }

    [Fact]
    public void MovieValidator_ShouldHaveValidationErrorFor_Actors()
    {
        // Arrange
        var validator = new MovieRequestValidator();
        var movieRequest = MovieObjectBuilder.GetMovieModel();
        var actor = movieRequest.Actors?.FirstOrDefault();
        if (actor != null) actor.FirstName = "";
        // Act
        var result = validator.TestValidate(movieRequest);

        // Assert
        result.ShouldHaveValidationErrorFor("Actors[0].FirstName");
    }
}
