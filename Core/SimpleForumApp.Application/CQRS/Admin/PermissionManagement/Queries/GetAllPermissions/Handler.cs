using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetAllPermissions
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
            var result = await _unitOfWork.Context.Auth.PermissionRepository.GetAllDetailsByStatusAsync(
                request.IsPassiveShown ? 2 : 1
            );

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Kayıt bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                Id = x.Id,
                StatusName = x.StatusName,
                Name = x.Name,
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
            }).ToList());
        }
    }
}
