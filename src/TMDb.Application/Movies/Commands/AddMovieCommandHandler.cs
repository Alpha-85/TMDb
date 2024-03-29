﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMDb.Application.Common.Interfaces;
using TMDb.Domain.Entities;

namespace TMDb.Application.Movies.Commands;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, int?>
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

    public async Task<int?> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        var exists = await _context.Movies
            .AsNoTracking()
            .Where(x => x.Title == request.Movie.Title)
            .FirstOrDefaultAsync(cancellationToken);

        if (exists is not null) return 0;

        var result = _mapper.Map<Movie>(request.Movie);

        _context.Movies.Add(result);
        _context.Actors.AddRange(result.Actors);
        _context.Genres.AddRange(result.Genres);
        

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            _logger.LogError("Database Error: Failed to insert {request.Movie}", request.Movie);
            return null;
        }

        return result.Id;

    }
}
