using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMDb.Application.Common.Models.RequestModels;
using TMDb.Application.Movies.Commands;
using TMDb.Application.Movies.Queries;

namespace TMDb.WebApi.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public MovieController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Add a new movie to the database.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Adds a new movie</returns>
    /// <response code="400">If validation fails on post. Check error messages.</response>
    /// <response code="201">the "Id" of the newly added movie.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] MovieModel request,CancellationToken cancellationToken)
    {

        var result = await _mediator.Send(new AddMovieCommand(request), cancellationToken);

        if (result is null)
            return BadRequest();

        return CreatedAtAction("Get", new { id = result }, result);
    }

    /// <summary>
    /// Gets a specific movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="404">If the movie isn't found.</response>
    /// <response code="200">Retrieves selected movie.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMovieQuery(id), cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Deletes a specific movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <response code="404">If the movie isn't found.</response>
    /// <response code="202">Request is accepted and handled.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteMovieCommand(id), cancellationToken);

        if (result is false)
            return NotFound();

        return Accepted();
    }
}
