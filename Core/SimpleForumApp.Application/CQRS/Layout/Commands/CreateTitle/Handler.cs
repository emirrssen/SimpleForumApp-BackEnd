using Microsoft.AspNetCore.Http;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Layout.Commands.CreateTitle
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async override Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (userName == null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var currentUser = await _unitOfWork.Context.Identity.UserService.GetByUserNameAsync(userName);

            if (currentUser == null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var allTitles = await _unitOfWork.Context.App.TitleRepository.GetAllAsync();

            if (allTitles.Any(x => x.Subject.Replace(" ", "").ToLower() == request.Subject.Replace(" ", "").ToLower()))
                return ResultFactory.FailResult("Bu isimde bir başlık geçmişte zaten açılmış");

            if (request.AuthorTypeId == (long)AuthorTypes.User)
            {
                await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

                long authorId = 0;
                var currentAuthor = await _unitOfWork.Context.App.AuthorRepository.GetByUserIdAsync(currentUser.Id);

                if (currentAuthor == null)
                {
                    var authorInsertResult = await _unitOfWork.Context.App.AuthorRepository.InsertAsync(new()
                    {
                        GroupId = null,
                        UserId = currentUser.Id,
                        StatusId = 1,
                        CreatedDate = DateTime.Now,
                        AuthorTypeId = (long)AuthorTypes.User
                    });

                    if (authorInsertResult <= 0)
                    {
                        await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                        return ResultFactory.FailResult("Başlık oluşturma işlemi başarısız");
                    }

                    authorId = authorInsertResult;
                }

                var insertResult = await _unitOfWork.Context.App.TitleRepository.InsertAsync(new()
                {
                    AuthorId = currentAuthor == null ? authorId : currentAuthor.Id,
                    CreatedDate = DateTime.Now,
                    StatusId = 1,
                    Subject = request.Subject,
                    Content = request.Content
                });

                if (insertResult <= 0)
                {
                    await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                    return ResultFactory.FailResult("Başlık oluşturma işlemi başarısız");
                }

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult("Başlık başarıyla oluşturuldu");
            }

            return ResultFactory.FailResult("Geçersiz yazar tipi");
        }
    }
}
