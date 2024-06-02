using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Auth.Commands.ResetPassword
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Kullanıcı belirtilmesi zorunludur");

            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token belirtilmesi zorunludur");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre belirtilmesi zorunludur");
        }
    }
}
