using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Queries.GetMatchingsByRoleId
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Rol seçimi zorunludur")
                .GreaterThan(0).WithMessage("Rol seçimi zorunludur");
        }
    }
}
