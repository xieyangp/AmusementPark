using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
    public async Task<IActionResult> LoginAsync([FromQuery] LoginRequest request)
    {
        var response = await _mediator.RequestAsync<LoginRequest, LoginResponse>(request);

        return Ok(response);
    }
}