using System.Reflection;
using Autofac;
using Mediator.Net;
using Mediator.Net.Autofac;
using Microsoft.Extensions.Configuration;
using PractiseForJohnny.Core.Services;
using Mediator = Mediator.Net.Mediator;
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
        RegisterMediator(builder);
        
        RegisterDependency(builder);
    }
    
    private void RegisterDependency(ContainerBuilder builder)
    {
        foreach (var type in typeof(IService).Assembly.GetTypes()
            .Where(t => typeof(IService).IsAssignableFrom(t) && t.IsClass))
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

    private void RegisterMediator(ContainerBuilder builder)
    {
        var mediatorBuidler = new MediatorBuilder();

        mediatorBuidler.RegisterHandlers(_assemblies);

        builder.RegisterMediator(mediatorBuidler);
    }
}