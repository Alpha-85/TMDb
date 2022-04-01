using MediatR;
using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Movies.Queries;

public record GetMovieQuery(in int MovieId) : IRequest<MovieModel>
{
    public int MovieId { get; set; } = MovieId;
}
