using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using AmusementPark.Message.Commands.UserQuestion;
using AmusementPark.Message.Requests;

namespace AmusementPark.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SmartFaqController : ControllerBase
{
    private readonly IMediator _mediator;

    public SmartFaqController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Route("faqs/review"), HttpGet]
    public async Task<IActionResult> GetUserQuestionsForReviewAsync([FromQuery] GetUserQuestionsForReviewRequest request)
    {
        var response = await _mediator.RequestAsync<GetUserQuestionsForReviewRequest, GetUserQuestionsForReviewResponse>(request).ConfigureAwait(false);

        return Ok(response);
    }
    
    [Route("faqs/correct"), HttpPost]
    public async Task<IActionResult> UpdateUserQuestions([FromBody] UpdateUserQuestionsCommand command)
    {
        var response = await _mediator.SendAsync<UpdateUserQuestionsCommand, UpdateUserQuestionsResponse>(command).ConfigureAwait(false);

        return Ok(response);
    }
}