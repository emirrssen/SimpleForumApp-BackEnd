using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.Insert
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı seçimi zorunludur")
                .GreaterThan(0).WithMessage("Kullanıcı seçimi zorunludur");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Rol seçimi zorunludur")
                .GreaterThan(0).WithMessage("Rol seçimi zorunludur");
        }
    }
}
