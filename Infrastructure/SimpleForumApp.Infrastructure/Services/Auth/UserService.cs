using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Domain.DTOs.Auth.UserDtos;
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

        public async Task<UserFullDetail> GetUserFullDetailByUserNameAsync(string userName)
        {
            var result = await _userManager.Users
                .Where(x => x.UserName == userName)
                .Include(x => x.Person)
                    .ThenInclude(x => x.Country)
                .Include(x => x.Person)
                    .ThenInclude(x => x.Gender)
                .Select(x => new UserFullDetail()
                {
                    CountryId = x.Person.CountryId,
                    FirstName = x.Person.FirstName,
                    LastName = x.Person.LastName,
                    CountryName = x.Person.Country.Name,
                    CreatedDate = x.Person.CreatedDate,
                    DateOfBirth = x.Person.CreatedDate,
                    Email = x.Email,
                    GenderId = x.Person.GenderId,
                    GenderName = x.Person.Gender.Name,
                    Id = x.Id,
                    PersonId = x.PersonId,
                    PhoneNumber = x.PhoneNumber,
                    ProfileImage = x.Person.ProfileImage,
                    StatusId = x.Person.StatusId,
                    UpdatedDate = x.Person.UpdatedDate,
                    UserName = x.UserName
                })
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Result> InsertAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded
                ? ResultFactory.SuccessResult()
                : ResultFactory.WarningResult(string.Join("\n", result.Errors.Select(x => x.Description)));
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
