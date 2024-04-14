using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.CQRS.Auth.Queries.Login
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
