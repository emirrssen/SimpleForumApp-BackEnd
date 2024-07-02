using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface ITokenService : IInjectable
    {
        Token CreateAccessToken(int expirationMinute);
        string CreateRefreshToken(int expirationMinute);
    }
}
