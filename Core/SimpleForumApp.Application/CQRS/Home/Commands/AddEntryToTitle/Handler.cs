using Microsoft.AspNetCore.Http;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Enums;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Commands.AddEntryToTitle
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

        public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (currentUserName == null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var currentUser = await _unitOfWork.Context.Identity.UserService.GetByUserNameAsync(currentUserName);

            if (currentUser == null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            if (request.AuthorTypeId == (long)AuthorTypes.User)
            {
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
                        return ResultFactory.FailResult("Entry oluşturma işlemi başarısız");
                    }

                    authorId = authorInsertResult;
                }

                var insertResult = await _unitOfWork.Context.App.EntryRepository.InsertAsync(new()
                {
                    AuthorId = currentAuthor == null ? authorId : currentAuthor.Id,
                    Content = request.Entry,
                    CreatedDate = DateTime.Now,
                    StatusId = 1,
                    TitleId = request.TitleId
                });

                if (insertResult <= 0)
                {
                    await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                    return ResultFactory.FailResult("Entry oluşturma işlemi başarısız");
                }

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult("Entry başarıyla oluşturuldu");
            }

            return ResultFactory.FailResult("Geçersiz yazar tipi");
        }
    }
}
