using AmusementPark.Core.Services;

namespace AmusementPark.Core.Service;

public interface IHelloWordService : IScopedDependency
{
    public string SayHello();
}