using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Infrastructure.Configurations.Identity
{
    public class UserValidationConfigurations : IUserValidator<User>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new();

            var userToCheck = await manager.GetPhoneNumberAsync(user);

            if (userToCheck is not null)
            {
                errors.Add(new() { Code = "PhoneNumberAlreadyTaken", Description = "Bu telefon numarası başka bir kullanıcı tarafından kullanılıyor." });
            }

            return errors.Any()
                ? IdentityResult.Failed(errors.ToArray())
                : IdentityResult.Success;
        }
    }
}
