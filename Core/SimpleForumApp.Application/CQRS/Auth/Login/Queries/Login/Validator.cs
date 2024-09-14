using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Auth.Login.Queries.Login
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresinin belirtilmesi zorunludur");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrenin belirtilmesi zorunludur");
        }
    }
}
