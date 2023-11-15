using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PingPongController : Controller
{
   private readonly IMediator _mediator;

   public PingPongController(IMediator mediator)
   {
      _mediator = mediator;
   }

   [HttpPost]
   public async Task<IActionResult> CreatePingAsync([FromBody] PingCommand command)
   {
      var response = await _mediator.SendAsync<PingCommand, PongResponse>(command).ConfigureAwait(false);

      return Ok(response);
   }
}