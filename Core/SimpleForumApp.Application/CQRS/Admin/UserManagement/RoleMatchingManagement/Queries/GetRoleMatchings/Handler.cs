using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Queries.GetRoleMatchings
{
    public class Handler : QueryHandlerBase<Query, IList<Response>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<IList<Response>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.Auth.UserRoleRepository.GetDetailsByUserIdAsync(request.UserId);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Bu kullanıcı için henüz bir eşleşme yapılmamıştır.");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
                RoleId = x.RoleId,
                RoleName = x.RoleName,
                StatusId = x.StatusId
            }).ToList());
        }
    }
}
