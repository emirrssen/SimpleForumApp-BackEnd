using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Commands.BulkUpdate
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.ItemsToUpdate)
                .NotEmpty().WithMessage("Güncellenecek elemanların seçimi zorunludur");
        }
    }
}
