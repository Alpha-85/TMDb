using MediatR;
using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Movies.Queries;

public record GetMovieQuery(int MovieId) : IRequest<MovieModel>;

