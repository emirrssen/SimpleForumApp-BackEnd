using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands.Insert
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.PermissionId)
                .NotEmpty().WithMessage("Yetki seçimi zorunludur")
                .GreaterThan(0).WithMessage("Yetki seçimi zorunludur");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Rol seçimi zorunludur")
                .GreaterThan(0).WithMessage("Rol seçimi zorunludur");
        }
    }
}
