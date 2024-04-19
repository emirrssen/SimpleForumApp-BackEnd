using SimpleForumApp.Domain.DTOs.Auth;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface ITokenService
    {
        Token CreateAccessToken(int expirationMinute);
        string CreateRefreshToken(int expirationMinute);
    }
}
