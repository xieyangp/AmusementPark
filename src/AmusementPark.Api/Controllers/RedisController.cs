using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using AmusementPark.Core.Services.Caching;
using AmusementPark.Message.DTO.UserAccount;

namespace AmusementPark.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RedisController : ControllerBase
{
    private IMediator _mediator;
    private ICachingService _redisCacheService;

    public RedisController(IMediator mediator, ICachingService redisCacheService)
    {
        _mediator = mediator;
        _redisCacheService = redisCacheService;
    }

    [Route("set"), HttpPost]
    public async Task<IActionResult> SetRedisForStringAsync(UserAccountDto user)
    {
        await _redisCacheService.SetAsync($@"{user.Id}", user).ConfigureAwait(false);

        return Ok(user);
    }

    [Route("Get"), HttpGet]
    public async Task<IActionResult> GetRedisForStringAsync(int key)
    {
        var cacheUser = await _redisCacheService.GetAsync<UserAccountDto>($@"{key}").ConfigureAwait(false);

        return Ok(cacheUser);
    }
}