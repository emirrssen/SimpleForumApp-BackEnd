using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetAllByStatus
{
    public class Validator : ValidatorBase<Query>
    {
        public Validator()
        {
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("End point'in durumunun seçilmesi zorunludur");
        }
    }
}
