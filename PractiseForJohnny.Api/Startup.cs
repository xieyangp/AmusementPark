using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PractiseForJohnny.Core.IService;
using PractiseForJohnny.Core.Service.HelloWorld;

namespace PractiseForJohnny.Api;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddControllers();
        services.AddScoped<IHelloWordService, HelloWordService>();
        // services.AddSwaggerGen(c =>
        // {
        //     c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Your API", Version = "v1" });
        // });
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
       
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // app.UseSwagger();
        // app.UseSwaggerUI(c =>
        // {
        //     c.SwaggerEndpoint("/swagger/v1/swagger.json","Your API V1");
        // });
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}