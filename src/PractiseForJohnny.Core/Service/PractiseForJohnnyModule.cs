using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using PractiseForJohnny.Core.IService;
using Module = Autofac.Module;

namespace PractiseForJohnny.Core.Service;

public class PractiseForJohnnyModule : Module
{
    private readonly Assembly[] _assemblies;
    private readonly IConfiguration _configuration;

    public PractiseForJohnnyModule(IConfiguration configuration, params Assembly[] assemblies)
    {
        _assemblies = assemblies;
        _configuration = configuration;
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        RegisterDependency(builder);
    }
    
    private void RegisterDependency(ContainerBuilder builder)
    {
        foreach (var type in typeof(IService.IService).Assembly.GetTypes()
            .Where(t => typeof(IService.IService).IsAssignableFrom(t) && t.IsClass))
        {
            switch (type)
            {
                case var t when typeof(IScopedDependency).IsAssignableFrom(type):
                    builder.RegisterType(t).AsImplementedInterfaces().InstancePerLifetimeScope();
                    break;
                case var t when typeof(ISingletonService).IsAssignableFrom(type):
                    builder.RegisterType(t).AsImplementedInterfaces().SingleInstance();
                    break;
                case var t when typeof(ITransientDependency).IsAssignableFrom(type):
                    builder.RegisterType(t).AsImplementedInterfaces().InstancePerDependency();
                    break;
                default:           
                    builder.RegisterType(type).AsImplementedInterfaces();
                    break;
            }
        }
    }
}