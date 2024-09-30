using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetAgenda
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
            var result = await _unitOfWork.Context.App.TitleRepository.GetTitlesOpenedTodayAsAgendaAsync();

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Bugün için açılan herhangi bir başlık yok.");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                EntryNumber = x.EntryNumbers + "",
                TitleId = x.Id,
                TitleSubject = x.TitleSubject
            }).ToList());
        }
    }
}
