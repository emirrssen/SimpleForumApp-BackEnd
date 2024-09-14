using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.ResetPassword.Commands.ResetPassword
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Context.Identity.AuthService.ResetPasswordAsync(
                request.UserId,
                request.Token,
                request.Password
            );
        }
    }
}
