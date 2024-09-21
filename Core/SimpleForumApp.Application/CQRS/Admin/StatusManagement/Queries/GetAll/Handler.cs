using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.StatusManagement.Queries.GetAll
{
    public class Handler : QueryHandlerBase<Query, IList<Response>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<ResultWithData<IList<Response>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Context.App.StatusRepository.GetAllAsync();

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Durum bilgisi bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                Id = x.Id,
                Title = x.Name
            }).ToList());
        }
    }
}
