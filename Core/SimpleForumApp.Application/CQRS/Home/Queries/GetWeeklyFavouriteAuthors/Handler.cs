using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetWeeklyFavouriteAuthors
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
            var result = await _unitOfWork.Context.App.AuthorRepository.GetWeeklyFavouriteAuthorsAsync();

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Bu hafta hiçbir yazar başlık açmamış");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                AuthorId = x.AuthorId,
                Username = x.Username
            }).ToList());
        }
    }
}
