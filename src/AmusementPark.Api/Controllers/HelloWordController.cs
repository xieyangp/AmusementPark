using Microsoft.AspNetCore.Mvc;
using AmusementPark.Core.Service;

namespace AmusementPark.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWordController : ControllerBase
{
    private readonly IHelloWordService _helloWordService;

    public HelloWordController(IHelloWordService helloWordService)
    {
        _helloWordService = helloWordService;
    }
    
    [HttpGet]
    public IActionResult Hello()
    {
        return Ok(_helloWordService.SayHello());
    }
}