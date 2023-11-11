using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using PractiseForJohnny.Core.IService;
using PractiseForJohnny.Core.Service.HelloWorld;


namespace PractiseForJohnny.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        // var builder = new ContainerBuilder();
        // builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        //     .Where(t => t.Name.StartsWith("HelloWordService"))
        //     .AsImplementedInterfaces()
        //     .InstancePerLifetimeScope();
        // var container = builder.Build();
        // var serviceProvider = new AutofacServiceProvider(container);
        
        CreateHostBuilder(args).Build().Run(); //如果没有改代码，启动立马就会停止
        // var builder = new ContainerBuilder();
        // builder.RegisterType<HelloWordService>().As<IHelloWordService>();
        // builder.Build();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    //       .ConfigureContainer<ContainerBuilder>(builder =>
    // builder.RegisterType<HelloWordService>().As<IHelloWordService>());

}