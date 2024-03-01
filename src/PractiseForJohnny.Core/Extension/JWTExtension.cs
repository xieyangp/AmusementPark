using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PractiseForJohnny.Core.Auth;
using System.Text;

namespace PractiseForJohnny.Core.Extension
{
    /// <summary>
    /// Jwt 相关扩展
    /// </summary>
    public static class JWTExtension
    {
        public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtBearer = configuration.GetSection(AppSettings.Authentication).GetSection(AppSettings.JwtBearer);
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidIssuer = jwtBearer.GetValue<string>(AppSettings.Issuer),//Issuer

                    ValidateAudience = true,//是否验证Audience
                    ValidAudience = jwtBearer.GetValue<string>(AppSettings.Audience),//Audience

                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearer.GetValue<string>(AppSettings.SecurityKey))),//拿到SecurityKey

                    ValidateLifetime = true,//是否验证失效时间
                    ClockSkew = TimeSpan.FromSeconds(5)//偏差秒数：防止客户端与服务器时间偏差
                };
            });
        }
    }
}
