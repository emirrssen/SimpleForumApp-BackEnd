using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Commands.UpdateById
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yetkinin belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Yetkinin belirtilmesi zorunludur");

            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Yetkinin durumunun belirtilmesi zorunludur")
                .GreaterThan(0).WithMessage("Yetkinin durumunun belirtilmesi zorunludur");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Yetkinin isminin belirtilmesi zorunludur");
        }
    }
}
