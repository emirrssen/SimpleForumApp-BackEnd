using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetTitles
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
            var result = await _unitOfWork.Context.App.TitleRepository.GetAllForPreviewTitlesAsync();

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Henüz bir başlık açılmamış");

            return ResultFactory.SuccessResult<IList<Response>>(result.Select(x => new Response
            {
                CreatedAuthor = x.AuthorName,
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
                LikeNumber = x.LikeNumber + "",
                TitleContent = x.Content,
                TitleId = x.Id,
                TitleSubject = x.Subject
            }).ToList());
        }
    }
}
