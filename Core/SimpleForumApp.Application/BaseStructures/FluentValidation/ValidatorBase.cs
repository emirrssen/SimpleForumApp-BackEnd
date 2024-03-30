using FluentValidation;
using SimpleForumApp.Application.BaseStructures.MediatR;

namespace SimpleForumApp.Application.BaseStructures.FluentValidation
{
    public class ValidatorBase<TQuery> : AbstractValidator<TQuery> where TQuery : IBase { }
}
