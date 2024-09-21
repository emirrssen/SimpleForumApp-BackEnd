using FluentValidation;
using SimpleForumApp.Application.BaseStructures.FluentValidation;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.Commands.UpdateById
{
    public class Validator : ValidatorBase<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı seçimi zorunludur")
                .GreaterThan(0).WithMessage("Kullanıcı seçimi zorunludur");

            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Durum seçimi zorunludur")
                .GreaterThan(0).WithMessage("Durum seçimi zorunludur");

            RuleFor(x => x.GenderId)
                .NotEmpty().WithMessage("Cinsiyet seçimi zorunludur")
                .GreaterThan(0).WithMessage("Cinsiyet seçimi zorunludur");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Ülke seçimi zorunludur")
                .GreaterThan(0).WithMessage("Ülke seçimi zorunludur");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Doğum tarihinin belirtilmesi zorunludur");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsmin belirtilmesi zorunludur");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyismin belirtilmesi zorunludur");
        }
    }
}
