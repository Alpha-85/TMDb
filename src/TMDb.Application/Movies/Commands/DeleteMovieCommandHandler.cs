using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMDb.Application.Common.Interfaces;

namespace TMDb.Application.Movies.Commands;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<DeleteMovieCommandHandler> _logger;

    public DeleteMovieCommandHandler(IApplicationDbContext context, ILogger<DeleteMovieCommandHandler> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies
            .Include(a => a.Actors)
            .Include(g => g.Genres)
            .Where(m => m.Id == request.MovieId)
            .FirstOrDefaultAsync(cancellationToken);

        if (movie is null)
            return false;

        _context.Movies.Remove(movie);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            _logger.LogError("Failed to Remove Entity from database with id: {request.MovieId}", request.MovieId);

            return false;
        }

        return true;
    }
}
