using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Auth.Commands.ChangePassword
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Mevcut şifre girilmesi zorunludur");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Yeni şifre belirtilmesi zorunludur");

            RuleFor(x => x.NewPasswordRepeat)
                .NotEmpty().WithMessage("Yeni şifre tekrarı belirtilmesi zorunludur")
                .Equal(x => x.NewPassword).WithMessage("Yeni şifre ve şifre tekrarı aynı olmalıdır");
        }
    }
}
