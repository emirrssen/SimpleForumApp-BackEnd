using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetDetailsById
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
            var result = await _unitOfWork.Context.Traceability.EndPointRepository.GetDetailsByIdAsync(request.Id);

            if (result == null)
                return ResultFactory.FailResult<Response>("End point bulunamadı");

            return ResultFactory.SuccessResult<Response>(new Response
            {
                Id = result.Id,
                ActionTypeName = result.ActionTypeName,
                ControllerName = result.ControllerName,
                IsActive = result.IsActive,
                IsUse = result.IsUse,
                MethodName = result.MethodName,
                Route = result.Route,
                Description = result.Description
            });
        }
    }
}
