using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands.Insert
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.EndPointId)
                .NotEmpty().WithMessage("End point seçimi zorunludur")
                .GreaterThan(0).WithMessage("End point seçimi zorunludur");

            RuleFor(x => x.PermissionId)
                .NotEmpty().WithMessage("Yetki seçimi zorunludur")
                .GreaterThan(0).WithMessage("Yetki seçimi zorunludur");
        }
    }
}
