using FluentValidation;
using TMDb.Application.Common.Models.RequestModels;

namespace TMDb.Application.Common.Validators;

public class MovieRequestValidator : AbstractValidator<MovieRequestModel>
{
    public MovieRequestValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(100)
            .MinimumLength(5)
            .Matches("^[a-zA-Z0-9 ]*$")
            .NotEmpty();

        RuleFor(v => v.Director)
            .MaximumLength(100)
            .MinimumLength(5)
            .Matches("^[a-zA-Z0-9 ]*$")
            .NotEmpty();

        RuleFor(v => v.Synopsis)
            .MaximumLength(200)
            .MinimumLength(5)
            .NotEmpty();

        RuleFor(v => v.Year)
            .GreaterThanOrEqualTo(1895)
            .NotNull();

        RuleFor(v => v.Genres)
            .NotNull()
            .NotEmpty();

        RuleForEach(x => x.Actors).ChildRules(child =>
        {
            child.RuleFor(x => x.FirstName).NotEmpty();
            child.RuleFor(d => d.LastName).NotEmpty();
        });

    }
}