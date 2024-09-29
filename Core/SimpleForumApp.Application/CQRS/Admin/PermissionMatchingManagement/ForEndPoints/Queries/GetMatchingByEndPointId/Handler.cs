using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Queries.GetMatchingByEndPointId
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
            var result = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetAllPermissionDetailsByEndPointAsync(request.EndPointId);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Bu end point için yetki bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                EndPointId = x.EndPointId,
                PermissionId = x.PermissonId,
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
                PermissionName = x.PermissionName,
                StatusId = x.StatusId
            }).ToList());
        }
    }
}
