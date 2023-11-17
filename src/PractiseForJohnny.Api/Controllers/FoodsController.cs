using Mediator.Net;
using Mediator.Net.Contracts;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRepository _repository;

    public FoodsController(IMediator mediator, IRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateFoodAsync([FromBody] CreateFoodCommand command)
    {
        var response = await _mediator.SendAsync<CreateFoodCommand, CreateFoodResponse>(command).ConfigureAwait(false);

        return Ok(response);
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateFoodAsync([FromBody] UpdateFoodCommand command)
    {
        var result = await _mediator.SendAsync<UpdateFoodCommand, UpdateFoodResponse>(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    [Route("delete")]
    public async Task<IActionResult> DeleteFoodAsync([FromBody] DeleteFoodCommand command)
    {
        var result = await _mediator.SendAsync<DeleteFoodCommand, DeleteFoodResponse>(command).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    [Route("get")]
    public async Task<IActionResult> GetFoodAsync([FromBody] GetFoodRequest request)
    {
        var result = await _mediator.RequestAsync<GetFoodRequest, GetFoodResponse>(request).ConfigureAwait(false);

        return Ok(result);
    }
}