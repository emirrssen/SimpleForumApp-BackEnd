using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Application.Services.Auth;
using SimpleForumApp.Domain.Entities.Auth;
using SimpleForumApp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<Result> LoginAsync(string email, string password)
        {
            var userTologin = await _userManager.FindByEmailAsync(email);

            if (userTologin is null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(userTologin!, password, false);

            if (!result.Succeeded)
                return ResultFactory.SuccessResult("Kullanıcı adı veya şifre hatalı");

            return ResultFactory.SuccessResult("Giriş başarılı");
        }
    }
}
