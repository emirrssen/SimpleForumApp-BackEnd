using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionManagement.Queries.GetById
{
    public class Handler : QueryHandlerBase<Query, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<ResultWithData<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.Auth.PermissionRepository.GetByIdAsync(request.Id);

            if (result == null)
                return ResultFactory.WarningResult<Response>("Yetki bulunamadı");

            return ResultFactory.SuccessResult(new Response
            {
                Id = result.Id,
                Description = result.Description,
                Name = result.Name,
                StatusId = result.StatusId,
            });
        }
    }
}
