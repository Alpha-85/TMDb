using MediatR;
using TMDb.Application.Common.Models.RequestModels;

namespace TMDb.Application.Movies.Commands;

public record AddMovieCommand(in MovieModel Movie) : IRequest<int?>
{
    public MovieModel Movie { get; set; } = Movie;
}
