using PractiseForJohnny.Core.Services;

namespace PractiseForJohnny.Core.Service;

public interface IHelloWordService : IScopedDependency
{
    public string SayHello();
}