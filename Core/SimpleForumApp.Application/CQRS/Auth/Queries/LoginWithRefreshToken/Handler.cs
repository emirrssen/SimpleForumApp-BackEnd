using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.DTOs.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.Queries.LoginWithRefreshToken
{
    public class Handler : QueryHandlerBase<Query, Token>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<Token>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Identity.AuthService.LoginWithRefreshTokenAsync(request.RefreshToken);

            if (!result.IsSuccess)
                return ResultFactory.FailResult<Token>(result.Message);

            return ResultFactory.SuccessResult<Token>(result.Data);
        }
    }
}
