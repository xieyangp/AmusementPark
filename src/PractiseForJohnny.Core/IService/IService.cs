namespace PractiseForJohnny.Core.IService;

public interface IService
{

}


/// <summary>
/// 每个服务请求都会返回一个唯一的实例。
/// </summary>
public interface IInstancePerDependency : IService
{
    
}

/// <summary>
/// 全局共享一个服务对象。适用于服务无状态对象。
/// </summary>
public interface ISingletonService : IService
{
   
}

/// <summary>
/// 在每个生命周期范围内创建一个实例，不同生命周期范围中的实例是独立的
/// </summary>
public interface IInstancePerLifetimeScope : IService
{
    
}
