using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Infrastructure.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            var result = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == userName);
            return result;
        }

        public async Task<Result> InsertAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded
                ? ResultFactory.SuccessResult()
                : ResultFactory.FailResult(string.Join("\n", result.Errors.Select(x => x.Description)));
        }

        public async Task<Result> UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenExpireDate, int refreshTokenLifeTime)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = accessTokenExpireDate.AddMinutes(refreshTokenLifeTime);

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return ResultFactory.FailResult(string.Join("\n", updateResult.Errors.Select(x => x.Description)));
            }
            
            return ResultFactory.SuccessResult();
        }
    }
}
