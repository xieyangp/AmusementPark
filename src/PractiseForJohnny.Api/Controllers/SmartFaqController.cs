using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Message.Commands.UserQuestion;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SmartFaqController : ControllerBase
{
    private readonly IMediator _mediator;

    public SmartFaqController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("get")]
    public async Task<IActionResult> GetUserQuestionsForReviewAsync([FromBody] GetUserQuestionsRequest command)
    {
        var response = await _mediator.RequestAsync<GetUserQuestionsRequest, GetUserQuestionsForReviewResponse>(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateUserQuestions([FromBody] UpdateUserQuestionCommand command)
    {
        var response = await _mediator.SendAsync<UpdateUserQuestionCommand, UpdateUserQuestionResponse>(command);

        return Ok(response);
    }
}