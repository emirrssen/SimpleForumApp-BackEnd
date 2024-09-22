using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.EndPointManagement.Queries.GetAllByStatus
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
            var result = await _unitOfWork.Context.Traceability.EndPointRepository.GetDetailsByStatusAsync(request.IsActive);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Sistemde kayıtlı end-point bulunamadı.");

            return ResultFactory.SuccessResult<IList<Response>>(
                result
                    .GroupBy(x => x.ControllerName)
                    .Select(x => new Response
                    {
                        ControllerName = x.Key,
                        EndPoints = x.Where(y => y.ControllerName == x.Key).Select(y => new EndPoint
                        {
                            ActionTypeName = y.ActionMethodName,
                            EndPointRoute = y.Route,
                            Id = y.Id,
                            IsActive = y.IsActive ? "Evet" : "Hayır",
                            IsUse = y.IsUse ? "Evet" : "Hayır",
                            MethodName = y.MethodName
                        }).ToArray()
                    })
                    .ToList()
            );
        }
    }
}
