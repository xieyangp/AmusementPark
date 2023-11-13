using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Core.IService;

namespace PractiseForJohnny.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HelloWordController : Controller
{
    private readonly IHelloWordService _helloWordService;

    public HelloWordController(IHelloWordService helloWordService)
    {
        _helloWordService = helloWordService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_helloWordService.SayHello());
    }
}