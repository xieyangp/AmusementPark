using Microsoft.Extensions.Configuration;

namespace PractiseForJohnny.Core.Setting.System;

public class ConnectionString : IConfiguartionSetting<string>
{
    public string Value { get; set; }
    
    public ConnectionString(IConfiguration configuration)
    {
        Value = configuration.GetConnectionString("Default");
    }
}