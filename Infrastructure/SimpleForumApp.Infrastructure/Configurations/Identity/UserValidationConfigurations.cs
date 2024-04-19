using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Domain.Entities.Auth;

namespace SimpleForumApp.Infrastructure.Configurations.Identity
{
    public class UserValidationConfigurations : IUserValidator<User>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new();

            var userToCheck = await manager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == user.PhoneNumber && x.Id != user.Id);

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
