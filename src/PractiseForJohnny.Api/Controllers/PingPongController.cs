using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Request;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PingPongController : Controller
{
   private readonly IMediator _mediator;

   public PingPongController(IMediator mediator)
   {
      _mediator = mediator;
   }

   [HttpPost]
   public async Task<IActionResult> CreatePingAsync([FromBody]PingCommand input)
   {
      var response = await _mediator.SendAsync<PingCommand, PongResponse>(input).ConfigureAwait(false);
      
      return Ok(response);
   }
}