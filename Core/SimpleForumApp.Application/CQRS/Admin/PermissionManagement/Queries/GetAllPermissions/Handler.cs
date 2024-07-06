using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetAllPermissions
{
    public class Handler : QueryHandlerBase<Query, IList<Dto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<IList<Dto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.Auth.PermissionRepository.GetAllDetailsAsync();

            if (!result.Any())
            {
                return ResultFactory.FailResult<IList<Dto>>("Aktif kayıt bulunamadı");
            }

            return ResultFactory.SuccessResult<IList<Dto>>(result.Select(x => new Dto
            {
                Id = x.Id,
                StatusId = x.StatusId,
                StatusName = x.StatusName,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToList());
        }
    }
}
