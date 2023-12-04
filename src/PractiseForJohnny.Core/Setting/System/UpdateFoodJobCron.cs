using Microsoft.Extensions.Configuration;

namespace PractiseForJohnny.Core.Setting.System;

public class UpdateFoodJobCron : IConfiguartionSetting<string>
{
    public UpdateFoodJobCron(IConfiguration configuration)
    {
        Value = configuration["UpdateFoodJobCron:Cron"];
    }
    
    public string Value { get; set; }
}