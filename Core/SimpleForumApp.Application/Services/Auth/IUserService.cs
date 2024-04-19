using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface IUserService
    {
        Task<Result> InsertAsync(User user, string password);
        Task<Result> UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenExpireDate, int refreshTokenLifeTime);
    }
}
