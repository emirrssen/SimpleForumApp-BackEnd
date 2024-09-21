using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetAllPermissions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries.GetAll
{
    public class Handler : QueryHandlerBase<Query, IList<Response>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public override async Task<ResultWithData<IList<Response>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Context.Auth.RoleRepository.GetAllDetailsByStatusAsync(request.StatusId);

            if (!response.Any())
                return ResultFactory.WarningResult<IList<Response>>("Sistemde tanımlı rol bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(response.Select(x => new Response
            {
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                StatusName = x.StatusName
            }).ToList());
        }
    }
}
