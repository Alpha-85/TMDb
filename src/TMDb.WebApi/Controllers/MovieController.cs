using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMDb.Application.Common.Models.RequestModels;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(MovieRequestModel request)
    {
        throw new NotImplementedException();
    }
}
