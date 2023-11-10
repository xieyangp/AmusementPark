using Microsoft.AspNetCore.Mvc;
using PractiseForJohnny.Core.IService;


namespace PractiseForJohnny.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HelloController : Controller
{
   private readonly IHelloWordService _helloWord;

   public HelloController(IHelloWordService helloWord)
   {
      _helloWord = helloWord;
   }

   [HttpGet]
   public IActionResult Hello()
   {
      return Ok(_helloWord.SayHello());
   }
}