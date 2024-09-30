using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Home.Commands.AddActionToTitle
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.ActionId)
                .NotEmpty().WithMessage("Aksiyon tipinin belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Aksiyon tipinin belirtilmesi zorunludur");

            RuleFor(x => x.TitleId)
                .NotEmpty().WithMessage("Başlığın belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Başlığın belirtilmesi zorunludur");
        }
    }
}
