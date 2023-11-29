using System.Data;
using DbUp.Engine;

namespace PractiseForJohnny.Core.Dbup;

public class Scripts0003_initial_tables : IScript
{
   
    public string ProvideScript(Func<IDbCommand> dbCommandFactory)
    {
        return @"create table if not exists user_question
                    (
                        id int auto_increment primary key,
                        created_at int not null,
                        question varchar(512) charset utf8 not null,
                        rasa_predicted_qid int not null,
                        rasa_confidence decimal(8,3) null,
                        anyq_confidence decimal(8,3) null,
                        anyq_predicted_qid int not null,
                        model3_predicted_qid int default 0 null,
                        model3_confidence decimal(8,3) default 0.000 null,
                        correct_qid int not null,
                        status int default 0 null,
                        remark varchar(512) charset utf8 null,
                        ask_by varchar(128) charset utf8 null
                        )charset=utf8mb4;";
    }
}