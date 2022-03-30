using MediatR;
using TMDb.Application.Common.Models.RequestModels;

namespace TMDb.Application.Movies.Commands;

public record AddMovieCommand(in MovieRequestModel Movie) : IRequest<bool>
{
    public MovieRequestModel Movie { get; set; } = Movie;
}
