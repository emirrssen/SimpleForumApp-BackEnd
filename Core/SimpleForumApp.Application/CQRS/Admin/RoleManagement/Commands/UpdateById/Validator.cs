using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Commands.UpdateById
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Rol seçimi zorunludur")
                .GreaterThan(0).WithMessage("Rol seçimi zorunludur");

            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Rolün durumunun belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Rolün durumunun belirtilmesi zorunludur");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rolün isminin belirtilmesi zorunludur");
        }
    }
}
