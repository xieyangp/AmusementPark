using DbUp;
using DbUp.ScriptProviders;

namespace PractiseForJohnny.Core.Dbup;

public class DbUpRunner
{
    private readonly string _connectionString;

    public DbUpRunner(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Run()
    {
        EnsureDatabase.For.MySqlDatabase(_connectionString);
        
        string outPutDirectory = Path.GetFullPath("../PractiseForJohnny.Core/DbUp");
        
        var upgradeEngine = DeployChanges.To.MySqlDatabase(_connectionString)
            .WithScriptsAndCodeEmbeddedInAssembly(typeof(DbUpRunner).Assembly,s => s.Contains("0002"))
            .WithScriptsFromFileSystem(outPutDirectory, new FileSystemScriptOptions { IncludeSubDirectories = true ,Filter = s => s.Contains("0001")})
            .WithTransaction()
            .LogToAutodetectedLog()
            .LogToConsole()
            .Build();

        var result = upgradeEngine.PerformUpgrade();

        if (!result.Successful)
            throw result.Error;
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
    }
}