using Microsoft.AspNetCore.Http;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Home.Commands.AddActionToTitle
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
            var currentUserName = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (currentUserName == null)
                return ResultFactory.FailResult("Kullanıcı bulunamadı");

            var currentUser = await _unitOfWork.Context.Identity.UserService.GetByUserNameAsync(currentUserName);

            var currentTitleActions = await _unitOfWork.Context.App.TitleActionRepository.GetByTitleIdAndUserIdAsync(
                request.TitleId, currentUser.Id
            );

            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            if (!currentTitleActions.Any(x => x.ActionId == request.ActionId))
            {
                if (currentTitleActions.Count() == 1)
                {
                    var currentTitleAction = currentTitleActions.First(x => x.ActionId != request.ActionId);

                    currentTitleAction.StatusId = 3;
                    currentTitleAction.UpdatedDate = DateTime.Now;

                    await _unitOfWork.Context.App.TitleActionRepository.UpdateAsync(currentTitleAction);
                }

                var insertResult = await _unitOfWork.Context.App.TitleActionRepository.InsertAsync(new()
                {
                    ActionId = request.ActionId,
                    CreatedDate = DateTime.Now,
                    StatusId = 1,
                    TitleId = request.TitleId,
                    UserId = currentUser.Id
                });

                if (insertResult != request.TitleId)
                {
                    await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
                    return ResultFactory.FailResult("Bir hata meydana geldi");
                }

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult();
            }

            if (currentTitleActions.Any(x => x.ActionId == request.ActionId) && currentTitleActions.Count() == 2)
            {
                var currentTitleAction = currentTitleActions.First(x => x.ActionId == request.ActionId);
                var otherTitleAction = currentTitleActions.First(x => x.ActionId != request.ActionId);

                currentTitleAction.StatusId = 1;
                currentTitleAction.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.App.TitleActionRepository.UpdateAsync(currentTitleAction);

                otherTitleAction.StatusId = 3;
                otherTitleAction.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.App.TitleActionRepository.UpdateAsync(otherTitleAction);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult();
            }

            if (currentTitleActions.Any(x => x.ActionId == request.ActionId) && currentTitleActions.Count() == 1)
            {
                var currentTitleAction = currentTitleActions.First(x => x.ActionId == request.ActionId);
                
                currentTitleAction.StatusId = 1;
                currentTitleAction.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.App.TitleActionRepository.UpdateAsync(currentTitleAction);

                await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
                return ResultFactory.SuccessResult();
            }

            await _unitOfWork.Database.EfCoreDb.RollbackTransactionAsync();
            return ResultFactory.FailResult("Bir hata meydana geldi");
        }
    }
}
