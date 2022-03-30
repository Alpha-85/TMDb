using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMDb.Application.Common.Models.RequestModels;
using TMDb.Application.Movies.Commands;

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
    public async Task<IActionResult> Create([FromBody] MovieRequestModel request,CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddMovieCommand(request), cancellationToken);

        if (result is false)
            return BadRequest();

        return Ok();
    }
}
