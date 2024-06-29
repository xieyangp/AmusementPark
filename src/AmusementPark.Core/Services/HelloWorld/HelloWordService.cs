using AmusementPark.Core.Service;

namespace AmusementPark.Core.Service;

public class HelloWordService : IHelloWordService
{
    public string SayHello()
    {
        return "hello";
    }
}