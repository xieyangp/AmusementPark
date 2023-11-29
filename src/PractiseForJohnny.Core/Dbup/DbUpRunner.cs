using DbUp;

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
        EnsureDatabase.For.MySqlDatabase(_connectionString);//确保数据库是否存在，如果不存在则创建新数据库
        
       

        var upgradeEngine = DeployChanges.To.MySqlDatabase(_connectionString)
            .WithScriptsAndCodeEmbeddedInAssembly(typeof(DbUpRunner).Assembly, s => s.EndsWith(".cs"))
            .WithTransaction()//用于在执行脚本时启用事务。它确保在执行脚本期间，如果发生错误，将回滚所有已执行的更改
            .LogToAutodetectedLog()//用于自动检测并配置日志记录器。它根据可用的日志记录库自动选择适当的日志记录器。
            .LogToConsole()//将日志输出到控制台
            .Build();//构建升级引擎。

        var result = upgradeEngine.PerformUpgrade();//PerformUpgrade:用于执行数据库升级。它将执行所有未执行的脚本，并将执行结果返回给result变量。

        if (!result.Successful) throw result.Error;//判断升级是否成功
            
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
    }
}