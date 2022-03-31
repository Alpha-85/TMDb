using MediatR;
using TMDb.Application.Common.Models.RequestModels;

namespace TMDb.Application.Movies.Commands;

public record AddMovieCommand(in MovieRequestModel Movie) : IRequest<int?>
{
    public MovieRequestModel Movie { get; set; } = Movie;
}
