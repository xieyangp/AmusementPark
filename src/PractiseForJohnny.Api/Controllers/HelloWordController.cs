using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Core.Service;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class HelloWordController : Controller
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