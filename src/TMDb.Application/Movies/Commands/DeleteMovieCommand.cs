using MediatR;

namespace TMDb.Application.Movies.Commands;

public record DeleteMovieCommand(int MovieId) : IRequest<bool>;

