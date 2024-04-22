using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Core.Services.Caching;
using PractiseForJohnny.Message.DTO.UserAccount;

namespace PractiseForJohnny.Api.Controllers;

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