using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.CountryManagement.Queries.GetCountries
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
            var result = await _unitOfWork.Context.App.CountryRepository.GetAllAsync();

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>(Array.Empty<Response>(), "Ülke bulunamadı");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                Id = x.Id,
                Title = x.Name
            }).ToList());
        }
    }
}
