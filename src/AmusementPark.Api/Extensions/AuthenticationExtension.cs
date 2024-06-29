using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AmusementPark.Core.Setting.Authentication;

namespace AmusementPark.Api.Extensions;

public static class AuthenticationExtension
{
    public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = 
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(new JwtSymmetricKeySetting(configuration).Value
                                .PadRight(256 / 8, '\0')))
                };
            });
    }
}