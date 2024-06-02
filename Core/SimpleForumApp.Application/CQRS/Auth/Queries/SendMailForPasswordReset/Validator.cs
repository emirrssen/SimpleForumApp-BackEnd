using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Auth.Queries.SendMailForPasswordReset
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresinin belirtilmesi zorunludur")
                .EmailAddress().WithMessage("E-posta adresinin formatı hatalı");
        }
    }
}
