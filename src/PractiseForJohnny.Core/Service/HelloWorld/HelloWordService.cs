using PractiseForJohnny.Core.IService;
using PractiseForJohnny.Core.IService.IHelloWord;

namespace PractiseForJohnny.Core.Service.HelloWorld;

public class HelloWordService : IHelloWordService
{
    public string SayHello()
    {
        return "hello";
    }
}