using Autofac.Extensions.DependencyInjection;
using PractiseForJohnny.Core.Setting.System;
using PractiseForJohnny.Message.Dbup;

namespace PractiseForJohnny.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        
        new DbupRunner(new ConnectionString(configuration).Value).Run();
        
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}