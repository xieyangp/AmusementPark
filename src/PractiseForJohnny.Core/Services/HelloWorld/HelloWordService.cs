using PractiseForJohnny.Core.Service;

namespace PractiseForJohnny.Core.Service;

public class HelloWordService : IHelloWordService
{
    public string SayHello()
    {
        return "hello";
    }
}