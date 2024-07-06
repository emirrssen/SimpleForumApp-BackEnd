using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.TokenDtos;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface ITokenService : IInjectable
    {
        Token CreateAccessToken(int expirationMinute, User user);
        string CreateRefreshToken(int expirationMinute);
    }
}
