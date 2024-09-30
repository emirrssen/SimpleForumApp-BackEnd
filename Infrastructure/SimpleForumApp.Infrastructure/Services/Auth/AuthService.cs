using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.DTOs.Auth.TokenDtos;
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

        public async Task<Result> SendResetPasswordMailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordLink = $"http://localhost:3000/auth/reset-password?user-id={user.Id}&token={passwordResetToken}";

            await _unitOfWork.Context.Notification.EmailService.SendMailForPasswordResetAsync(user.Email!, resetPasswordLink);

            return ResultFactory.SuccessResult();
        }

        public async Task<ResultWithData<Token>> LoginAsync(string email, string password)
        {
            var userToLogin = await _userManager.FindByEmailAsync(email);

            if (userToLogin is null)
                return ResultFactory.FailResult<Token>("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(userToLogin!, password, true);

            if (result.IsLockedOut)
                return ResultFactory.FailResult<Token>("5'ten fazla yanlış giriş yaptığınız için hesabınız 5 dakika boyunca girişe kapatıldı");

            if (!result.Succeeded)
                return ResultFactory.FailResult<Token>("Kullanıcı adı veya şifre hatalı");

            var tokenResult = _unitOfWork.Context.Identity.TokenService.CreateAccessToken(60, userToLogin);

            var refreshTokenUpdateResult = await _unitOfWork.Context.Identity.UserService.UpdateRefreshTokenAsync(tokenResult.RefreshToken, userToLogin, tokenResult.ExpirationDate, 15);

            if (!refreshTokenUpdateResult.IsSuccess)
                return ResultFactory.FailResult<Token>(refreshTokenUpdateResult.Message!);

            return ResultFactory.SuccessResult<Token>("Giriş başarılı", tokenResult);
        }

        public async Task<ResultWithData<Token>> LoginWithRefreshTokenAsync(string refreshToken)
        {
            var userToLogin = await _userManager.Users.SingleOrDefaultAsync(x => x.RefreshToken == refreshToken && x.RefreshTokenEndDate > DateTime.Now);

            if (userToLogin is null)
            {
                return ResultFactory.FailResult<Token>("Kullanıcı bulunamadı");
            }

            var token = _unitOfWork.Context.Identity.TokenService.CreateAccessToken(60, userToLogin);

            var refreshTokenUpdateResult = await _unitOfWork.Context.Identity.UserService.UpdateRefreshTokenAsync(
                    token.RefreshToken, userToLogin, token.ExpirationDate, 60
                );

            if (!refreshTokenUpdateResult.IsSuccess)
            {
                return ResultFactory.FailResult<Token>("Kimlik doğrulama başarısız");
            }

            return ResultFactory.SuccessResult<Token>(token);
        }

        public async Task<Result> ResetPasswordAsync(long id, string token, string password)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var result = await _userManager.ResetPasswordAsync(user, token, password);

            if (!result.Succeeded)
                return ResultFactory.FailResult(string.Join("\n", result.Errors.Select(x => x.Description)));

            return ResultFactory.SuccessResult("Şifreniz başarıyla yenilenmiştir");
        }

        public async Task<Result> ValidatePasswordTokenAsync(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var result = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);

            if (!result)
                return ResultFactory.FailResult("Bir hata meydana geldi");

            return ResultFactory.SuccessResult();
        }

        public async Task<Result> ChangePasswordAsync(string email, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var checkPassword = await _userManager.CheckPasswordAsync(user, currentPassword);

            if (!checkPassword)
                return ResultFactory.FailResult("Mevcut şifreniz hatalı");

            var updateResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!updateResult.Succeeded)
                return ResultFactory.FailResult(string.Join(",", updateResult.Errors.Select(x => x.Description)));

            return ResultFactory.SuccessResult();
        }
    }
}
