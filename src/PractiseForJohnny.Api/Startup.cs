using Autofac;
using Hangfire;
using Microsoft.OpenApi.Models;
using PractiseForJohnny.Core.Service;
using PractiseForJohnny.Core.Hangfire;

namespace PractiseForJohnny.Api;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddControllers();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PractiseForJohnny", Version = "v1" });
        });

        services.AddHangFireService(Configuration);
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
        
        app.UseRouting();
        
        app.UseHangfireServer();
        app.UseHangfireDashboard();
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}