using MediatR;
using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Movies.Commands;

public record AddMovieCommand(MovieModel Movie) : IRequest<int?>;