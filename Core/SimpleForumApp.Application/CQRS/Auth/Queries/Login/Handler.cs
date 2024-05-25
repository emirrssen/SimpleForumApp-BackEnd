using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.DTOs.Auth;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Auth.Queries.Login
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
            var loginResult = await _unitOfWork.Context.Identity.AuthService.LoginAsync(request.Email, request.Password);

            if (!loginResult.IsSuccess)
                return ResultFactory.FailResult<Token>(loginResult.Message!);

            return ResultFactory.SuccessResult<Token>(loginResult.Message!, loginResult.Data!);
        }   
    }
}
