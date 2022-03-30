using System.Data.Common;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TMDb.Application.Common.Interfaces;
using TMDb.Domain.Entities;

namespace TMDb.Application.Movies.Commands;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<AddMovieCommandHandler> _logger;
    private readonly IMapper _mapper;

    public AddMovieCommandHandler(IApplicationDbContext context, ILogger<AddMovieCommandHandler> logger, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<bool> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {

        var result = _mapper.Map<Movie>(request.Movie);

        _context.Actors?.AddRange(result.Actors);
        _context.Genres?.AddRange(result.Genres);
        _context.Movies?.Add(result);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbException exception)
        {
            _logger.LogError("Database Error: Failed to insert {exception}", exception);
            return false;
        }

        return true;

    }
}
