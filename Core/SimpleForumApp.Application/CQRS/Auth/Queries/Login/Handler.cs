using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Application.CQRS.Auth.Queries.Login
{
    public class Handler : QueryHandlerBase<Query, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<bool>> Handle(Query request, CancellationToken cancellationToken)
        {
            var loginResult = await _unitOfWork.AuthService.LoginAsync(request.Email, request.Password);

            if (!loginResult.IsSuccess)
                return ResultFactory.FailResult<bool>(loginResult.Message!);

            return ResultFactory.SuccessResult<bool>(loginResult.Message!);
        }   
    }
}
