using PractiseForJohnny.Core.IService;

namespace PractiseForJohnny.Core.Service.HelloWorld;

public class HelloWordService:IHelloWordService
{
    public string SayHello()
    {
        return "hello";
    }
}