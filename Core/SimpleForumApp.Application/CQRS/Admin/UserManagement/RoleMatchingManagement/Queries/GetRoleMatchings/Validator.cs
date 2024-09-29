using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Queries.GetRoleMatchings
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı seçimi zorunludur")
                .GreaterThan(0).WithMessage("Kullanıcı seçimi zorunludur");
        }
    }
}
