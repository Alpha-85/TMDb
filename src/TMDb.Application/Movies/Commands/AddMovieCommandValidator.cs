using FluentValidation;

namespace TMDb.Application.Movies.Commands;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {
        RuleFor(v => v.Movie.Title)
            .MaximumLength(100)
            .MinimumLength(5)
            .Matches("^[a-zA-Z0-9 ]*$")
            .NotEmpty();

        RuleFor(v => v.Movie.Director)
            .MaximumLength(100)
            .MinimumLength(5)
            .Matches("^[a-zA-Z0-9 ]*$")
            .NotEmpty();

        RuleFor(v => v.Movie.Synopsis)
            .MaximumLength(200)
            .MinimumLength(5)
            .Matches("^[a-zA-Z0-9 ]*$")
            .NotEmpty();

        RuleFor(v => v.Movie.Year)
            .GreaterThanOrEqualTo(1895)
            .NotNull();

        RuleFor(v => v.Movie.Genres)
            .IsInEnum();

        RuleForEach(x => x.Movie.Actors).ChildRules(child =>
        {
            child.RuleFor(x => x.FirstName).NotEmpty();
            child.RuleFor(d => d.LastName).NotEmpty();
        });

    }
}
