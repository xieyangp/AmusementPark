using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PractiseForJohnny.Core.Setting.Authentication;

namespace PractiseForJohnny.Core.Services.Account;

public interface ITokenProvider : IScopedDependency
{
    string Genrate(List<Claim> claims);
}

public class TokenProvider : ITokenProvider
{
    private readonly JwtSymmetricKeySetting _jwtSymmetricKey;

    public TokenProvider(JwtSymmetricKeySetting jwtSymmetricKey)
    {
        _jwtSymmetricKey = jwtSymmetricKey;
    }

    public string Genrate(List<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _jwtSymmetricKey.Value.PadRight(256 / 8, '\0'))), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}