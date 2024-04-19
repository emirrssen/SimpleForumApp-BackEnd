using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.DTOs.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultWithData<Token>> LoginAsync(string email, string password)
        {
            var userToLogin = await _userManager.FindByEmailAsync(email);

            if (userToLogin is null)
                return ResultFactory.FailResult<Token>("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(userToLogin!, password, false);

            if (!result.Succeeded)
                return ResultFactory.SuccessResult<Token>("Kullanıcı adı veya şifre hatalı");

            var tokenResult = _unitOfWork.Identity.TokenService.CreateAccessToken(1);

            var refreshTokenUpdateResult = await _unitOfWork.Identity.UserService.UpdateRefreshToken(tokenResult.RefreshToken, userToLogin, tokenResult.ExpirationDate, 1);

            if (!refreshTokenUpdateResult.IsSuccess)
                return ResultFactory.FailResult<Token>(refreshTokenUpdateResult.Message!);

            return ResultFactory.SuccessResult<Token>("Giriş başarılı", tokenResult);
        }

        public async Task<ResultWithData<Token>> LoginWithRefreshTokenAsync(string refreshToken)
        {
            var userToLogin = await _userManager.Users.SingleOrDefaultAsync(x => x.RefreshToken == refreshToken && x.RefreshTokenEndDate > DateTime.UtcNow);

            if (userToLogin is null)
            {
                return ResultFactory.FailResult<Token>("Kullanıcı bulunamadı");
            }

            var token = _unitOfWork.Identity.TokenService.CreateAccessToken(1);

            var refreshTokenUpdateResult = await _unitOfWork.Identity.UserService.UpdateRefreshToken(
                    token.RefreshToken, userToLogin, token.ExpirationDate, 1
                );

            if (!refreshTokenUpdateResult.IsSuccess)
            {
                return ResultFactory.FailResult<Token>("Kimlik doğrulama başarısız");
            }

            return ResultFactory.SuccessResult<Token>(token);
        }
    }
}
