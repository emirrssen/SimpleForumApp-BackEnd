using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Layout.Commands.CreateTitle
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.AuthorTypeId)
                .NotEmpty().WithMessage("Yazar tipinin belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Yazar tipinin belirtilmesi zorunludur");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konunun belirtilmesi zorunludur");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçeriğin belirtilmesi zorunludur");
        }
    }
}
