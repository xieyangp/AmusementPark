using System.Data;
using DbUp.Engine;

namespace PractiseForJohnny.Message.Dbup.Scripts_2023;

public class Scripts0002_initial_tables : IScript
{
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            return @"create table if not exists Foods
                        ( 
                            Id int not null primary key AUTO_INCREMENT, 
                            name varchar(50) not null,
                            color varchar(10) not null
                        ) charset=utf8mb4";
                 

        }
}