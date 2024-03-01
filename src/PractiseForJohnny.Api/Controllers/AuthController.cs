using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PractiseForJohnny.Core.Auth;
using PractiseForJohnny.Message.DTO.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PractiseForJohnny.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthLoginDto authLoginDto) 
        {
            if (authLoginDto.UserName == "admin" && authLoginDto.Password == "123456")
            {
                // 定义JWT的Payload部分
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,authLoginDto.UserName)
                };

                var jwtBearer = configuration.GetSection(AppSettings.Authentication).GetSection(AppSettings.JwtBearer);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearer.GetValue<string>(AppSettings.SecurityKey)));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var securityToken = new JwtSecurityToken(
                        issuer: jwtBearer.GetValue<string>(AppSettings.Issuer),
                        audience: jwtBearer.GetValue<string>(AppSettings.Audience),
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: creds
                    );
                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                return Ok(token);
            }
            else 
            {
                return BadRequest("用户名或密码错误");
            }
        }
    }
}
