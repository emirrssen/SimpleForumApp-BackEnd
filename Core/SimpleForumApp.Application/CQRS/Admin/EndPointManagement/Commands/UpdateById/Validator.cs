using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Commands.UpdateById
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("End point seçimi zorunludur")
                .GreaterThan(0).WithMessage("End point seçimi zorunludur");

            RuleFor(x => x.IsUse)
                .NotNull().WithMessage("End pointin kullanım bilgisinin belirtilmesi zorunludur");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("End pointin aktiflik durumunun belirtilmesi zorunludur");
        }
    }
}
