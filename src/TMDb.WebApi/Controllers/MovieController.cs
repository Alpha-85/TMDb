using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMDb.Application.Common.Models.RequestModels;
using TMDb.Application.Movies.Commands;
using TMDb.Application.Movies.Queries;

namespace TMDb.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

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
}
