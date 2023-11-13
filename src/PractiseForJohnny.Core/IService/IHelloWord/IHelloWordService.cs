using Microsoft.Extensions.DependencyInjection;

namespace PractiseForJohnny.Core.IService;

public interface IHelloWordService : IInstancePerLifetimeScope
{
    public string SayHello();
}