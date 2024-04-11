using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Infrastructure.Configurations.Identity
{
    public class PasswordValidationConfigurations : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
        {
            List<IdentityError> errors = new();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainsUserName", Description = "Kullanıcı adı şifre içerisinde bulunamaz." });
            }

            if (password.ToLower().StartsWith("123"))
            {
                errors.Add(new() { Code = "PasswordStartsWith123", Description = "Şifre '123' karakterleri ile başlayamaz." });
            }

            return errors.Any()
                ? Task.FromResult(IdentityResult.Failed(errors.ToArray()))
                : Task.FromResult(IdentityResult.Success);
        }
    }
}
