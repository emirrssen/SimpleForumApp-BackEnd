using Microsoft.IdentityModel.Tokens;
using SimpleForumApp.Application.Helpers;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Domain.DTOs.Auth.TokenDtos;
using SimpleForumApp.Domain.Entities.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SimpleForumApp.Infrastructure.Services.Auth
{
    public class TokenService : ITokenService
    {
        public Token CreateAccessToken(int expirationMinute, User user)
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
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
            );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken(expirationMinute);

            return token;
        }

        public string CreateRefreshToken(int expirationMinute)
        {
            byte[] number = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(number);

            return Convert.ToBase64String(number);
        }
    }
}
