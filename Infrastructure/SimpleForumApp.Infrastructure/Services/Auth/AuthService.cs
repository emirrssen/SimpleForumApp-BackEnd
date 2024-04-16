using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Domain.DTOs.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ResultWithData<Token>> LoginAsync(string email, string password)
        {
            var userToLogin = await _userManager.FindByEmailAsync(email);

            if (userToLogin is null)
                return ResultFactory.FailResult<Token>("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(userToLogin!, password, false);

            if (!result.Succeeded)
                return ResultFactory.SuccessResult<Token>("Kullanıcı adı veya şifre hatalı");

            var tokenResult = _tokenService.CreateAccessToken(5);

            return ResultFactory.SuccessResult<Token>("Giriş başarılı", tokenResult);
        }
    }
}
