using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Home.Commands.AddEntryToTitle
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.TitleId)
                .NotEmpty().WithMessage("Başlık seçimi zorunludur")
                .GreaterThan(0).WithMessage("Başlık seçimi zorunludur");

            RuleFor(x => x.Entry)
                .NotEmpty().WithMessage("Entry girilmesi zorunludur");

            RuleFor(x => x.AuthorTypeId)
                .NotEmpty().WithMessage("Yazar tipinin belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Yazar tipinin belirtilmesi zorunludur");
        }
    }
}
