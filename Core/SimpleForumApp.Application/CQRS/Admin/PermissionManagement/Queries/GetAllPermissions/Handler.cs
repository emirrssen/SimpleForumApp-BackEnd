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
            var result = await _unitOfWork.Context.Auth.PermissionRepository.GetAllDetailsByStatusAsync(
                request.IsPassiveShown ? 2 : 1
            );

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Dto>>("Kayıt bulunamadı");

            return ResultFactory.SuccessResult<IList<Dto>>(result.Select(x => new Dto
            {
                Id = x.Id,
                StatusName = x.StatusName,
                Name = x.Name,
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
            }).ToList());
        }
    }
}
