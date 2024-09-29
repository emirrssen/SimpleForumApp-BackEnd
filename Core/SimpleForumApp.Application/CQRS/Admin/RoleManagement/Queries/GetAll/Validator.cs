using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries.GetAll
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Durumun belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Durumun belirtilmesi zorunludur");
        }
    }
}
