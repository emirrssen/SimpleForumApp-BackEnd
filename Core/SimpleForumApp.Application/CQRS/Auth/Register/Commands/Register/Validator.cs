using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Auth.Register.Commands.Register
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Ülke seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Hatalı ülke seçimi.");

            RuleFor(x => x.GenderId)
                .NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Hatalı cinsiyet seçimi.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim girilmesi zorunludur.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim girilmesi zorunludur.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Doğum tarihi belirtilmesi zorunludur.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı girilmesi zorunludur.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("E-posta adresinnin girilmesi zorunludur.")
                .EmailAddress().WithMessage("E-posta adresinin formatı hatalı.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası girilmesi zorunludur.")
                .Length(11).WithMessage("Telefon numarasının formatı hatalı.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre belirtilmesi zorunludur.")
                .Equal(x => x.PasswordRepeat).WithMessage("Girilen şifreler aynı olmak zorundadır.");
        }
    }
}
