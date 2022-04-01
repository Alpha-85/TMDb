using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMDb.Application.Common.Interfaces;
using TMDb.Application.Common.Models.MovieModels;

namespace TMDb.Application.Movies.Queries;

public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieModel>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetMovieQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<MovieModel> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _applicationDbContext.Movies
            .Include(x => x.Actors)
            .Include(x => x.Genres)
            .Where(m => m.Id == request.MovieId)
            .Select(x => _mapper.Map<MovieModel>(x))
            .FirstOrDefaultAsync(cancellationToken);


        return movie ?? null;
    }
}
