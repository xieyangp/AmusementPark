using Microsoft.Extensions.Configuration;

namespace AmusementPark.Core.Setting.Authentication;

public class JwtSymmetricKeySetting : IConfiguartionSetting<string>
{
    public JwtSymmetricKeySetting(IConfiguration configuration)
    {
        Value = configuration.GetValue<string>("Authentication:Jwt:SymmetricKey");
    }

    public string Value { get; set; }
}