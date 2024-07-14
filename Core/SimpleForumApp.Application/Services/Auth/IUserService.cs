using SimpleForumApp.Application.UnitOfWork.Core;
using SimpleForumApp.Domain.DTOs.Auth.UserDtos;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.Services.Auth
{
    public interface IUserService : IInjectable
    {
        Task<Result> InsertAsync(User user, string password);
        Task<Result> UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenExpireDate, int refreshTokenLifeTime);
        Task<User> GetByUserNameAsync(string userName);
        Task<UserFullDetail> GetUserFullDetailByUserNameAsync(string userName);
    }
}
