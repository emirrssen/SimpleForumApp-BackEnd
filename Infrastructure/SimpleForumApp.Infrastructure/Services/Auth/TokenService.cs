using Microsoft.IdentityModel.Tokens;
using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Domain.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SimpleForumApp.Infrastructure.Services.Auth
{
    public class TokenService : ITokenService
    {
        public Token CreateAccessToken(int expirationMinute)
        {
            Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(AppSettingsReaderHelper.GetTokenSecurityKey()));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationDate = DateTime.UtcNow.AddMinutes(expirationMinute);
            JwtSecurityToken securityToken = new(
                audience: AppSettingsReaderHelper.GetTokenAudience(),
                issuer: AppSettingsReaderHelper.GetTokenIssuer(),
                expires: token.ExpirationDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
