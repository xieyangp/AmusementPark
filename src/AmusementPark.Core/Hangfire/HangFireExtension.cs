using Hangfire;
using Hangfire.MySql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmusementPark.Core.Hangfire;

public static class HangFireExtension
{
    public static void AddHangFireService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseStorage(
                new MySqlStorage(
                    configuration.GetConnectionString("Default"),
                    new MySqlStorageOptions
                    {
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        DashboardJobListLimit = 25000,
                        TransactionTimeout = TimeSpan.FromMilliseconds(1),
                        TablesPrefix = "Hangfire",
                    }
                )
            ));

        services.AddHangfireServer(options => options.WorkerCount = 1);
    }
}