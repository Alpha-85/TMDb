using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Common.Models;

public record PaginationResult(int NextPage,int TotalCount, IEnumerable<MovieModel> Movies);

