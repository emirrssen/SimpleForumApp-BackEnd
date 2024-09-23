using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetAllPermissions
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.IsPassiveShown)
                .NotNull().WithMessage("Durum bilgisinin belirtilmesi zorunludur");
        }
    }
}
