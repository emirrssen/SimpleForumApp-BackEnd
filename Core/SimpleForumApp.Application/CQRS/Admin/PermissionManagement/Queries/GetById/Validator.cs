using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetById
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yetki seçimi zorunludur")
                .GreaterThan(0).WithMessage("Yetki seçimi zorunludur");
        }
    }
}
