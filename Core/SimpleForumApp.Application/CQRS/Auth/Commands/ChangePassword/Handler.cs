using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.Commands.ChangePassword
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<Result> Handle(Command request, CancellationToken cancellationToken)
            => await _unitOfWork.Context.Identity.AuthService.ChangePasswordAsync(request.Email, request.CurrentPassword, request.NewPassword);
    }
}
