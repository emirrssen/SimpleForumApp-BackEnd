using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Auth.ResetPassword.Commands.VerifyPasswordToken
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta belirtilmesi zorunludur")
                .EmailAddress().WithMessage("E-posta belirtilmesi zorunludur");

            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token belirtilmesi zorunludur");
        }
    }
}
