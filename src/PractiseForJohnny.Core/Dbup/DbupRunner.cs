using DbUp;

namespace PractiseForJohnny.Message.Dbup;

public class DbupRunner
{
    private readonly string _connectionString;

    public DbupRunner(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Run()
    {
        var upgradEngin = DeployChanges.To.MySqlDatabase(_connectionString)
            .WithScriptsAndCodeEmbeddedInAssembly(typeof(DbupRunner).Assembly)
            .WithTransaction()
            .LogToAutodetectedLog()
            .LogToConsole()
            .Build();

        var result = upgradEngin.PerformUpgrade();

        if (!result.Successful)
            throw result.Error;
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
    }
}