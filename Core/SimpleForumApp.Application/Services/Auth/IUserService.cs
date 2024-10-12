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
        Task<Result> UpdateUserNameAsync(User user);
        Task<Result> UpdateEmailAsync(User user);
        Task<Result> UpdatePhoneNumberAsync(User user, string phoneNumber);
        Task<User> GetByUserNameAsync(string userName);
        Task<UserFullDetail> GetUserFullDetailByUserNameAsync(string userName);
        Task<IList<UserFullDetail>> GetUserFullDetailsAsync();
        Task<IList<UserToList>> GetAllUsersForListAsync(bool isPassiveShown);
        Task<User> GetByIdAsync(long id);
        Task<IList<User>> GetAllAsync();
    }
}
