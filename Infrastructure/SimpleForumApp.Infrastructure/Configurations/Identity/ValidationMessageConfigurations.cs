using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Infrastructure.Configurations.Identity
{
    public class ValidationMessageConfigurations : IdentityErrorDescriber
    {
        #region Password Validations

        public override IdentityError PasswordRequiresDigit() 
            => new() { Code = "PasswordRequiresDigit", Description = "Şifre, en az 1 sayısal karakter içermelidir." };

        public override IdentityError PasswordRequiresLower()
            => new() { Code = "PasswordRequiresLower", Description = "Şifre, en az 1 küçük karakter içermelidir." };

        public override IdentityError PasswordRequiresNonAlphanumeric()
            => new() { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifre, en az 1 özel karakter içermelidir." };

        public override IdentityError PasswordRequiresUpper()
            => new() { Code = "PasswordRequiresUpper", Description = "Şifre, en az 1 büyük karakter içermelidir." };

        public override IdentityError PasswordTooShort(int length)
            => new() { Code = "PasswordTooShort", Description = "Şifre, en az 8 karakterden oluşmalıdır." };

        #endregion

        #region Email Validations

        public override IdentityError DuplicateEmail(string email)
            => new() { Code = "DuplicateEmail", Description = "Bu e-posta adresi başka bir kullanıcı tarafından kullanılmaktadır." };

        public override IdentityError InvalidEmail(string? email)
            => new() { Code = "InvalidEmail", Description = "Girmiş olduğunuz e-posta adresi geçersizdir." };

        #endregion

        #region UserName Validations

        public override IdentityError DuplicateUserName(string userName)
            => new() { Code = "DuplicateUserName", Description = "Bu kullanıcı adı, başka bir kullanıcı tarafından kullanılmaktadır." };

        #endregion
    }
}
