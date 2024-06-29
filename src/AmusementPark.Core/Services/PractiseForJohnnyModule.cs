using System.Reflection;
using AmusementPark.Core.Data;
using AmusementPark.Core.Services;
using AmusementPark.Core.Services.Caching;
using AmusementPark.Core.Setting;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Mediator.Net;
using Mediator.Net.Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AmusementPark.Core.MiddleWares.UnifyResponse;
using AmusementPark.Core.MiddleWares.UnitOfWork;
using Module = Autofac.Module;

namespace AmusementPark.Core.Service;

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
        
        RegisterDbContext(builder);

        RegisterSettings(builder);

        RegisterAutoMapping(builder);
        
        RegisterCaching(builder);
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
        
        mediatorBuidler.ConfigureGlobalReceivePipe(x =>
        {
            x.UseUnitOfWork();
            x.UseUnifyResponse();
        });

        builder.RegisterMediator(mediatorBuidler);
    }
    
    private void RegisterCaching(ContainerBuilder builder)
    {
        builder.Register(cfx =>
        {
            var pool = cfx.Resolve<IRedisConnectionPool>();
            return pool.GetConnection();
        }).ExternallyOwned();
    }
    
    private void RegisterDbContext(ContainerBuilder builder)
    {
        builder.RegisterType<PratiseForJohnnyDbContext>()
            .AsSelf()
            .As<DbContext>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<EfRepository>().As<IRepository>().InstancePerLifetimeScope();
    }
    
    private void RegisterSettings(ContainerBuilder builder)
    {
        var settingTypes = typeof(PratiseForJohnnyDbContext).Assembly.GetTypes()
            .Where(t => t.IsClass && typeof(IConfiguartionSetting).IsAssignableFrom(t))
            .ToArray();

        builder.RegisterTypes(settingTypes).AsSelf().SingleInstance();
    }

    private void RegisterAutoMapping(ContainerBuilder builder)
    {
        builder.RegisterAutoMapper(typeof(PractiseForJohnnyModule).Assembly);
    }
}