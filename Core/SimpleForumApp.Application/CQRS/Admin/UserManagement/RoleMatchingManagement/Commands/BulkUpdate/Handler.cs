using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.UserManagement.RoleMatchingManagement.Commands.BulkUpdate
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            foreach (var item in request.ItemsToUpdate)
            {
                var currentItemToUpdate = await _unitOfWork.Context.Auth.UserRoleRepository.GetByUserIdAndRoleIdAsync(item.UserId, item.RoleId);

                if (currentItemToUpdate == null)
                    continue;

                if (currentItemToUpdate!.StatusId == item.StatusId)
                    continue;

                currentItemToUpdate.StatusId = item.StatusId;
                currentItemToUpdate.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.UserRoleRepository.UpdateAsync(currentItemToUpdate);
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
