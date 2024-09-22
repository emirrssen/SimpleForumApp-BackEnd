using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetDetailsById
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("End point seçimi zorunludur")
                .GreaterThan(0).WithMessage("End point seçimi zorunludur");
        }
    }
}
