using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodsController(PratiseForJohnnyDbContext pratiseForJohnnyDbContext, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateFood(CreateFoodCommand command)
    {
        var response = await _mediator.SendAsync<CreateFoodCommand, CreateFoodResponse>(command).ConfigureAwait(false);

        return Ok(response);
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateFood(UpdateFoodCommand command)
    {
        var result = await _mediator.SendAsync<UpdateFoodCommand, UpdateFoodResponse>(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteFood(DeleteFoodCommand command)
    {
        var result = await _mediator.SendAsync<DeleteFoodCommand, DeleteFoodResponse>(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    [Route("get")]
    public async Task<IActionResult> GetFood(GetFoodCommand command)
    {
        var result = await _mediator.SendAsync<GetFoodCommand, GetFoodResponse>(command).ConfigureAwait(false);

        return Ok(result);
    }
}