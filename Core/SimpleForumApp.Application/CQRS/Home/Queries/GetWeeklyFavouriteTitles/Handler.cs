using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetWeeklyFavouriteTitles
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
            var result = await _unitOfWork.Context.App.TitleRepository.GetTitlesFavouriteThisWeekAsync();

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Bu hafta hiç başlık açılmamış");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                TitleId = x.Id,
                TitleSubject = x.Subject
            }).ToList());
        }
    }
}
