using Microsoft.Extensions.Configuration;

namespace AmusementPark.Core.Setting.System;

public class UpdateFoodJobCron : IConfiguartionSetting<string>
{
    public UpdateFoodJobCron(IConfiguration configuration)
    {
        Value = configuration["SchedulingUpdateFoodJobCronExpression"];
    }
    
    public string Value { get; set; }
}