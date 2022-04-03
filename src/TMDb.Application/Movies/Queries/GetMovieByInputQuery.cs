using MediatR;
using TMDb.Application.Common.Models;
using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Movies.Queries;

public record GetMovieByInputQuery(int PageNumber, int PageSize, string SearchString) : IRequest<PaginationResult<MovieModel>>;
