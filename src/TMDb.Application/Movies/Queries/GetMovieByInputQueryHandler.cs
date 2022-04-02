using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMDb.Application.Common.Interfaces;
using TMDb.Application.Common.Models;
using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Movies.Queries;

public class GetMovieByInputQueryHandler : IRequestHandler<GetMovieByInputQuery, PaginationResult>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMovieByInputQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PaginationResult> Handle(GetMovieByInputQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.SearchString)) return new PaginationResult(new List<MovieModel>());

        var page = request.Next ?? 0;
        var pageSize = request.PageSize ?? 10;

        var movies = await _context.Movies
            .Include(x => x.Actors)
            .Include(x => x.Genres)
            .Where(movie => movie.Title.ToLower()
                .Contains(request.SearchString.ToLower()))
            .OrderBy(x => x.Title)
            .Select(movie => _mapper.Map<MovieModel>(movie))
            .ToListAsync(cancellationToken);

        var result = movies
            .Select(movie => movie)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsQueryable();

        return new PaginationResult(result);

    }
}
