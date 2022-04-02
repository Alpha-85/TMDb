using MediatR;
using TMDb.Application.Common.Models;

namespace TMDb.Application.Movies.Queries;

public record GetMovieByInputQuery(int? Next,int? PageSize,string SearchString) : IRequest<PaginationResult>;

