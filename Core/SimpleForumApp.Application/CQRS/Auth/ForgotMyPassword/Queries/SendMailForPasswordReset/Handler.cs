using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.ForgotMyPassword.Queries.SendMailForPasswordReset
{
    public class Handler : QueryHandlerBase<Query, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<string>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.Identity.AuthService.SendResetPasswordMailAsync(request.Email);

            if (!result.IsSuccess)
                return ResultFactory.FailResult<string>(result.Message);

            return ResultFactory.SuccessResult<string>(result.Message);
        }
    }
}
