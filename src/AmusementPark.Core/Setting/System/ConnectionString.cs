using Microsoft.Extensions.Configuration;

namespace AmusementPark.Core.Setting.System;

public class ConnectionString : IConfiguartionSetting<string>
{
    public string Value { get; set; }
    
    public ConnectionString(IConfiguration configuration)
    {
        Value = configuration.GetConnectionString("Default");
    }
}