using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries.GetById
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Rol seçimi zorunludur")
                .GreaterThan(0).WithMessage("Rol seçimi zorunludur");
        }
    }
}
