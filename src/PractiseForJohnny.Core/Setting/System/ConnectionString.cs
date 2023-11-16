using Microsoft.Extensions.Configuration;

namespace PractiseForJohnny.Core.Setting.System;

public class ConnectionString : IConfiguartionSetting<string>
{
    public ConnectionString(IConfiguration configuration)
    {
        Value = configuration.GetConnectionString("Default");
    }

    public string Value { get; set; }
}