using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using NSubstitute;
using AmusementPark.Core.Dbup;
using AmusementPark.Core.Service;
using AmusementPark.Core.Setting.System;

namespace PractiseForJohnny.IntegarationTests;

public partial class TestBase
{
    private readonly List<string> _tableRecordsDeletionExcludeList = new()
    {
        "schemaversions"
    };

    private void RunDbUpIfRequired()
    {
        if (!shouldRunDbUpDatabases.GetValueOrDefault(_databaseName, true)) return;

        new DbUpRunner(new ConnectionString(CurrentConfiguration).Value).Run();

        shouldRunDbUpDatabases[_databaseName] = false;
    }

    private void RegisterBaseContainer(ContainerBuilder containerBuilder, IConfiguration configuration)
    {
        containerBuilder.RegisterModule(
            new PractiseForJohnnyModule(configuration, typeof(PractiseForJohnnyModule).Assembly));

        containerBuilder.RegisterInstance(Substitute.For<IMemoryCache>()).AsImplementedInterfaces();
    }

    private IConfigurationRoot Registerconfiguration(ContainerBuilder containerBuilder)
    {
        var targetJson = $"appsettings{_testTopic}.json";
        File.Copy("appsettings.json", targetJson, true);
        dynamic jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(targetJson));
        jsonObj["ConnectionStrings"]["Default"] =
            jsonObj["ConnectionStrings"]["Default"].ToString()
                .Replace("Database=smart_faq", $"Database={_databaseName}");
        File.WriteAllText(targetJson, JsonConvert.SerializeObject(jsonObj));
        var configuration = new ConfigurationBuilder().AddJsonFile(targetJson).Build();
        containerBuilder.RegisterInstance(configuration).AsImplementedInterfaces();
        return configuration;
    }

    public async Task InitializeAsync()
    {
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    private void ClearDatabaseRecord()
    {
        try
        {
            var connection = new MySqlConnection(new ConnectionString(CurrentConfiguration).Value);

            var deleteStatements = new List<string>();

            connection.Open();

            using var reader = new MySqlCommand(
                    $"SELECT table_name FROM INFORMATION_SCHEMA.tables WHERE table_schema = '{_databaseName}';",
                    connection)
                .ExecuteReader();

            deleteStatements.Add($"SET SQL_SAFE_UPDATES = 0");
            while (reader.Read())
            {
                var table = reader.GetString(0);

                if (!_tableRecordsDeletionExcludeList.Contains(table))
                {
                    deleteStatements.Add($"DELETE FROM `{table}`");
                }
            }

            deleteStatements.Add($"SET SQL_SAFE_UPDATES = 1");

            reader.Close();

            var strDeleteStatements = string.Join(";", deleteStatements) + ";";

            new MySqlCommand(strDeleteStatements, connection).ExecuteNonQuery();

            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error cleaning up data, {_testTopic}, {ex}");
        }
    }

    public void Dispose()
    {
        ClearDatabaseRecord();
    }
}

