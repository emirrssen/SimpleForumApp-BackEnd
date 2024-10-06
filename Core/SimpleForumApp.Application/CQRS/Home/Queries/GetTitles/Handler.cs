using Microsoft.AspNetCore.Http;
using SimpleForumApp.Application.BaseStructures.MediatR.QueryAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Queries.GetTitles
{
    public class Handler : QueryHandlerBase<Query, IList<Response>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<ResultWithData<IList<Response>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.Identity.Name;

            long currentUserId = 0;

            if (currentUserName != null)
            {
                var currentUser = await _unitOfWork.Context.Identity.UserService.GetByUserNameAsync(currentUserName);
                currentUserId = currentUser.Id;
            }
                

            var result = await _unitOfWork.Context.App.TitleRepository.GetAllForPreviewTitlesAsync(currentUserId);

            if (!result.Any())
                return ResultFactory.WarningResult<IList<Response>>("Henüz bir başlık açılmamış");

            return ResultFactory.SuccessResult<IList<Response>>(result.OrderByDescending(x => x.CreatedDate).Select(x => new Response
            {
                CreatedAuthor = x.AuthorName,
                ActionId = x.ActionId,
                CreatedDate = x.CreatedDate.ToString("dd.MM.yyyy"),
                LikeNumber = x.LikeNumber + "",
                TitleContent = x.Content,
                TitleId = x.Id,
                TitleSubject = x.Subject
            }).ToList());
        }
    }
}
