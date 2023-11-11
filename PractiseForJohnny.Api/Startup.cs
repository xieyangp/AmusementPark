using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PractiseForJohnny.Core;
using PractiseForJohnny.Core.IService;
using PractiseForJohnny.Core.Service.HelloWorld;

namespace PractiseForJohnny.Api;
public class Startup
{

    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Your API", Version = "v1" });
        });
    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new PractiseForJohnnyModule(Configuration, typeof(PractiseForJohnnyModule).Assembly));
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
       
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json","Your API V1");
        });
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
    }
}