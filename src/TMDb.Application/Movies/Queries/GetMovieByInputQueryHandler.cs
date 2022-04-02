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
        var (pageNumber, requestSize, searchString) = request;

        if (string.IsNullOrEmpty(searchString)) return new PaginationResult(0, 0, new List<MovieModel>());

        var page = pageNumber < 1 ? 1 : pageNumber;
        var pageSize = requestSize < 1 ? 10 : requestSize > 100 ? 10 : requestSize;

        var movies = await _context.Movies
            .Include(movie => movie.Actors)
            .Include(movie => movie.Genres)
            .Where(movie => movie.Title.ToLower()
                .Contains(searchString.ToLower()))
            .OrderBy(movie => movie.Id)
            .Select(movie => _mapper.Map<MovieModel>(movie))
            .ToListAsync(cancellationToken);


        var result = movies
            .Select(movie => movie)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsQueryable();

        var totalCount = result.Count();

        var nextPage = totalCount <= 0 ? 0 : page + 1;

        return new PaginationResult(nextPage, totalCount, result);

    }
}
