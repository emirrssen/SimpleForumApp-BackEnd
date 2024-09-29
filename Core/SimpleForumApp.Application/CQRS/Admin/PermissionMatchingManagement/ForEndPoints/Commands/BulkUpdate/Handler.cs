using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleForumApp.Application.BaseStructures.MediatR.CommandAbstractions;
using SimpleForumApp.Application.UnitOfWork;
using SimpleForumApp.Domain.Results;

namespace SimpleForumApp.Application.CQRS.Admin.PermissionMatchingManagement.ForEndPoints.Commands.BulkUpdate
{
    public class Handler : CommandHandlerBase<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Database.EfCoreDb.BeginTransactionAsync();

            foreach (var item in request.ItemsToUpdate)
            {
                var currentItemToUpdate = await _unitOfWork.Context.Auth.EndPointPermissionRepository.GetByEndPointAndPermissionIdAsync(item.EndPointId, item.PermissionId);

                if (currentItemToUpdate == null)
                    continue;

                if (currentItemToUpdate!.StatusId == item.StatusId)
                    continue;

                currentItemToUpdate.StatusId = item.StatusId;
                currentItemToUpdate.UpdatedDate = DateTime.Now;

                await _unitOfWork.Context.Auth.EndPointPermissionRepository.UpdateAsync(currentItemToUpdate);
            }

            await _unitOfWork.Database.EfCoreDb.CommitTransactionAsync();
            return ResultFactory.SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
