using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Queries.GetUnmatchedPermissions
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.EndPointId)
                .NotEmpty().WithMessage("End point seçimi zorunludur")
                .GreaterThan(0).WithMessage("End point seçimi zorunludur");
        }
    }
}
