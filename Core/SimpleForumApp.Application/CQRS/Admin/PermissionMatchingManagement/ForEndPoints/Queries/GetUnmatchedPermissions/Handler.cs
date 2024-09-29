using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Queries.GetUnmatchedPermissions
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
            var permissions = await _unitOfWork.Context.Auth.PermissionRepository.GetAllDetailsByStatusAsync(1);

            if (!permissions.Any())
                return ResultFactory.WarningResult<IList<Response>>("Sistemde kayıtlı yetki bulunamadı");

            var permissionMatchings = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionsByEndPointAsync(request.EndPointId);

            List<Response> resultToReturn = new();

            permissions.ToList().ForEach(x =>
            {
                if (!permissionMatchings.Any(y => y.PermissionId == x.Id && y.StatusId != 3))
                {
                    resultToReturn.Add(new()
                    {
                        Id = x.Id,
                        CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
                        Name = x.Name,
                        StatusName = x.StatusName
                    });
                }
            });

            return ResultFactory.SuccessResult<IList<Response>>(resultToReturn);
        }
    }
}
