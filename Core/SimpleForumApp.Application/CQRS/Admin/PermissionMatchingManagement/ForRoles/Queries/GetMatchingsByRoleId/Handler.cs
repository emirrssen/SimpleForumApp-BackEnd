using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForRoles.Queries.GetMatchingsByRoleId
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
            var result = await _unitOfWork.Context.Auth.RolePermissionRepository.GetDetailsByRoleIdAsync(request.RoleId);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Bu rol için henüz bir eşleştirme yapılmamış");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
                PermissionId = x.PermissionId,
                PermissionName = x.PermissionName,
                StatusId = x.StatusId
            }).ToList());
        }
    }
}
