using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.RoleManagement.Queries.GetById
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
            var response = await _unitOfWork.Context.Auth.RoleRepository.GetByIdAsync(request.Id);

            if (response == null)
                return ResultFactory.WarningResult<Response>("Rol bulunamadı");

            return ResultFactory.SuccessResult<Response>(new Response
            {
                Id = response.Id,
                Description = response.Description,
                Name = response.Name,
                StatusId = response.StatusId
            });
        }
    }
}
