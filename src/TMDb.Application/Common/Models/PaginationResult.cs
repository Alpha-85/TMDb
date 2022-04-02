using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Common.Models;

public record PaginationResult(IEnumerable<MovieModel> Movies);

