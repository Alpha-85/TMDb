using FluentValidation;

namespace TMDb.Application.Movies.Commands;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {

    }
}
