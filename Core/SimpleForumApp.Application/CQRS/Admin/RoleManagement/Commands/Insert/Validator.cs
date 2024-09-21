using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Commands.Insert
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Rolün durumunun belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Rolün durumunun belirtilmesi zorunludur");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rolün isminin belirtilmesi zorunludur");
        }
    }
}
